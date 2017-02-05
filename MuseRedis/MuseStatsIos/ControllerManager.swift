//
//  ControllerManager.swift
//  Controller
//
//  Created by Anirudh Natarajan on 12/4/16.
//  Copyright © 2016 Kodikos. All rights reserved.
//

import Foundation

@objc class ControllerManager: NSObject{
    let redisServer = Redis()
    let ip = "10.3.103.255"
//    let ip = "127.0.0.1"
    let port = 6379
    var appDelegate: AppDelegate? = (UIApplication.shared.delegate as? AppDelegate)
    
    override init() {
        super.init()
        connect()
        redisServer.Command(Command: "LPUSH list 0")
        redisServer.Command(Command: "LPUSH list 0")
        let timer = Timer.scheduledTimer(timeInterval: 0.02, target: self, selector: Selector("sendData"), userInfo: nil, repeats: true)
    }
    
    func lol(){
        
    }
    
    private func connect() {
        redisServer.server(endPoint: ip, onPort: UInt16(port))
    }
    
    class var sharedInstance: ControllerManager {
        struct Static {
            static let instance = ControllerManager()
        }
        return Static.instance
    }
    
    func sendData(){
        if((appDelegate?.scanning) != nil){
            redisServer.Command(Command: "LSET list 0 \(appDelegate?.waves[0] as! Double)")
            redisServer.Command(Command: "LSET list 1 \(appDelegate?.waves[1] as! Double)")
            redisServer.Command(Command: "LSET list 2 \(appDelegate?.waves[2] as! Double)")
            redisServer.Command(Command: "LSET list 3 \(appDelegate?.waves[3] as! Double)")
            print("\(appDelegate?.waves[3] as! Double)")
        }
    }
    
}
