    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class ExitButton : MonoBehaviour {
        public void ExitGame()
        {
            print("Exiting...");
            Application.Quit();
        }
    }
