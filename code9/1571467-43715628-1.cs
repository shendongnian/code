    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class CraneMagnet : MonoBehaviour
        {
        private CraneTrigger craneTrigger;// This is calling only for controls
        public string getTag = "";// Define the tag in the inpector
        private Rigidbody objectPickedUp;
        [HideInInspector] public bool canLift = false;
        [HideInInspector] private bool isLifted = false;// only exists so the objectPickedUp cant be called until is exists 
        void Start()
        {
            craneTrigger = FindObjectOfType<CraneTrigger>();
        }
        void Update()
        {
            //call PickUpObject() in the control script
        }
 
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == getTag)
            {
                objectPickedUp = other.attachedRigidbody;// make the triggered RididBody become objectPIckedUP 
                craneTrigger.canPickup = true;
            }
        }
        public void PickUpObject()
        {
            if (canLift)
            {
                objectPickedUp.transform.parent = transform;// object becomes child of magnet 
                isLifted = true;
                objectPickedUp.isKinematic = true;// so object can be moved easier
            }
            if (!canLift && isLifted)
            {
                objectPickedUp.isKinematic = false;// so gravity will take over the fall
                objectPickedUp.transform.parent = null;//the picked up object looses magnet parent
                isLifted = false;
            }
        }
    }
