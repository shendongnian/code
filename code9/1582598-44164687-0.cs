    using UnityEngine;
    using UnityEngine.UI;
    using System.Collections;
    using System.Collections.Generic;
    namespace Vuforia
    {
        /// <summary>
        /// A custom handler that implements the ITrackableEventHandler interface.
        /// </summary>
        public class dtehedit : MonoBehaviour,
        ITrackableEventHandler
        {
    
            #region PRIVATE_MEMBER_VARIABLES
    
            private TrackableBehaviour mTrackableBehaviour;
            private bool firsttime = false;
            string itname = "";
            //private bool secondtime=false;
            GameObject lost, lostclone;
            #endregion // PRIVATE_MEMBER_VARIABLES
    
    
    
            #region UNTIY_MONOBEHAVIOUR_METHODS
    
            void Start()
            {
                Debug.Log("start method before registring");
                mTrackableBehaviour = GetComponent<TrackableBehaviour>();
                if (mTrackableBehaviour)
                {
                    mTrackableBehaviour.RegisterTrackableEventHandler(this);
                }
                Debug.Log("start method after registring");
            }
    
            #endregion // UNTIY_MONOBEHAVIOUR_METHODS
    
    
    
            #region PUBLIC_METHODS
    
            /// <summary>
            /// Implementation of the ITrackableEventHandler function called when the
            /// tracking state changes.
            /// </summary>
            public void OnTrackableStateChanged(
                TrackableBehaviour.Status previousStatus,
                TrackableBehaviour.Status newStatus)
            {
                if (newStatus == TrackableBehaviour.Status.DETECTED ||
                    newStatus == TrackableBehaviour.Status.TRACKED ||
                    newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
                {
                    OnTrackingFound();
                }
                else
                {
                    OnTrackingLost();
                }
            }
    
            #endregion // PUBLIC_METHODS
    
    
    
            #region PRIVATE_METHODS
    
    
            private void OnTrackingFound()
            {
                // This is wrong because you never set it to false. Every time a tracker(image) is found it will be the first time - wrong.
                //      firsttime = true;      
    
    
                if (lostclone != null)
                {
                    Debug.Log("LOST CLONE otf ::" + lostclone.name);
                    // DestroyObject(lostclone); // (1) if new object is scanned gameobject lostclone is not destroyed
                }
    
                //Here you can reset the position of the GameObject back to the parent(tracker)'s position. 
                this.transform.GetChild(0).transform.position = new Vector3(0, 0, 0);
    
                Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
                Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
    
                // Enable rendering:
                foreach (Renderer component in rendererComponents)
                {
                    component.enabled = true;
                }
    
                // Enable colliders:
                foreach (Collider component in colliderComponents)
                {
                    component.enabled = true;
                }
    
                Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
            }
    
    
            private void OnTrackingLost()
            {
                Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
                Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
    
                // What you can do is not disable this
                //foreach (Renderer component in rendererComponents)
                //{
                //    component.enabled = false;
                //}
    
                // Disable colliders: Disable this if you need it diabled only
                foreach (Collider component in colliderComponents)
                {
                    component.enabled = false;
                }
    
                string itname = mTrackableBehaviour.TrackableName;
                Debug.Log("lost trackable name " + itname);
                GameObject lost = GameObject.Find("IT" + itname);
                //(2) WOrking but dont know how to reposition gameobject after next tracker is found
    
                // This is not decoupling but it should work ( you dont need to find the gameobject you can use [this] instead)
                this.transform.GetChild(0).transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane + 20));
                // Disable rendering:
    
                itname = mTrackableBehaviour.TrackableName;
                Debug.Log("lost trackable name " + itname);
                lost = GameObject.Find("IT" + itname).transform.GetChild(0).gameObject;
                // this is not I ment by decoupling sory, I ment de parenting -> (gameObject.parent = null)
                //lostclone = Instantiate(lost) as GameObject; //decoupling
            }
    
            #endregion // PRIVATE_METHODS
        }
    }
