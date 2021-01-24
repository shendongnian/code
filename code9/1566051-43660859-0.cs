    using UnityEngine;
    using HTC.UnityPlugin.Vive;
    public class YourClass : MonoBehaviour
    {
        private void Update()
        {
            // get trigger
            if (ViveInput.GetPressDown(HandRole.RightHand, ControllerButton.Trigger))
            {
                // ...
            }
        }
    }
