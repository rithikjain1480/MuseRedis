using UnityEngine;
using System.Collections;
using System.Net.Sockets;
using UnityEngine.Networking;

[@RequireComponent(typeof(CharacterController))]
public class ControlPlayer : MonoBehaviour
{
    public float moveSpeed = 7f, jumpSpeed = 0.1f, jumpHeight = 2, camHeight = 3f, camDistance = 7f;

    private bool isJumping = false;
    private Vector3 lastPosition;
    private CharacterController cc;
    TcpClient myClient;
    NetworkStream datstr;
    bool isAtStartup;
    

    // Create a client and connect to the server port
    public void SetupClient()
    {
        myClient = new TcpClient();
       // myClient.RegisterHandler(MsgType.Connect, OnConnected);
        myClient.Connect("127.0.0.1", 6279);
        datstr = myClient.GetStream();
        isAtStartup = false;
    }

    // client function
    public void OnConnected(NetworkMessage netMsg)
    {
        Debug.Log("Connected to server");
    }

    // Create a local client and connect to the local server
    public void SetupLocalClient()
    {
       // myClient = ClientScene.ConnectLocalServer();
       // myClient.RegisterHandler(MsgType.Connect, OnConnected);
        isAtStartup = false;
    }

    void Jump()
    {
        if (cc.isGrounded) //якщо ми стоїмо на землі
            isJumping = false; //то ми не можемо стрибати
        if (Input.GetKeyDown(KeyCode.Space) && cc.isGrounded) //якщо ми стоїмо на землі і нажали на ПРОБІЛ
        {
            //то записуємо останню позицію гравця, і повідомляємо, що він буде зараз стрибати
            isJumping = true;
            lastPosition = transform.position;
        }
        if (isJumping) //якщо він стрибає
        {
            if (transform.position.y < jumpHeight + lastPosition.y) //якщо ми не дострибнули до верхньої межі 
                cc.Move(transform.up * jumpSpeed); //продовжуємо надавати силу стрибка гравцю
            else //по-іншому перестаємо надавати силу стрибка герою
                isJumping = false; //припиняємо стрибати, і задіюємо гравітацію
        }
    }

    void Start()
    {
        //знаходимо компонент CharacterController, для задання руху та гравітації героя
        cc = GetComponent<CharacterController>();
        SetupClient();
        //робимо камеру дочірньою до гравця, та записуємо потрібну позицію камери
        Camera.allCameras[0].transform.parent = transform;
        Camera.allCameras[0].transform.position = transform.position + new Vector3(0, camHeight, -camDistance);
    }
    void Update()
    {
        //повертаємо героя на 90 градусів(вліво, або вправо)
        if (Input.GetKeyDown(KeyCode.D))
            transform.Rotate(new Vector3(0, 90, 0));
        if (Input.GetKeyDown(KeyCode.A))
            transform.Rotate(new Vector3(0, -90, 0));


        //get the osc from network stream datstr and adjust moveSpeed accordingly
        byte[] temp = new byte[4];
        double[] dat = new double[4];
        datstr.Read(temp, 0, 4);
        for (int i = 0; i < 4; i++)
        {
            dat[i] = Convert.toDouble(temp[i]);
        }
        if (dat[0] < 0.25) moveSpeed = 4f;
        else moveSpeed = 7f;

        //рухаємо героя постійно вперед, відповідно до повороту
        cc.SimpleMove(transform.forward * moveSpeed);

        //викликаємо функцію стрибка
        Jump();
    }
}
