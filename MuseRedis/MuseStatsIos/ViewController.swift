//
//  ViewController.swift
//  MuseStatsIos
//
//  Created by Rithik Jain on 2/5/17.
//  Copyright © 2017 InteraXon. All rights reserved.
//

import Foundation
import UIKit

class ViewController: UIViewController {
    override func viewDidLoad() {
        super.viewDidLoad()
        ControllerManager.sharedInstance.lol()
        self.performSegue(withIdentifier: "movePage", sender: self)
    }
}
