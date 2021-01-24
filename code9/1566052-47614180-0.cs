    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class Grab: MonoBehaviour {
        private Valve.VR.InteractionSystem.Hand hand;
        void Start () {
            hand = gameObject.GetComponent<Valve.VR.InteractionSystem.Hand>();
        }
        void Update () {
            if (hand.controller == null) return;
            // Change the ButtonMask to access other inputs
            if (hand.controller.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                Debug.Log("Trigger down")
            }
            if (hand.controller.GetPress(SteamVR_Controller.ButtonMask.Trigger))
            {
                Debug.Log("Trigger still down")
            }
            if (hand.controller.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                Debug.Log("Trigger released")
            }
        }
    }
