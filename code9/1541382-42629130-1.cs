    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class MapDetect : MonoBehaviour {
     void OnTriggerEnter(Collider other)
     {
         if (other.gameObject.CompareTag("Player"))
         {
             Debug.Log ("Map ON");
         } 
     }
     void OnTriggerExit(Collider other)
     {
         if (other.gameObject.CompareTag("Player"))
         {
             Debug.Log ("Map OFF");
         }
     }
    }
