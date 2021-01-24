     using UnityEngine;
     using System.Collections;
     
     public class LookAt : MonoBehaviour {
         public Vector3 target;
         
         // Update is called once per frame
         void Update () {
             transform.LookAt(target);
         }
     }
