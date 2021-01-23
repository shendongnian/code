    using UnityEngine;
    using System.Collections;
 
    public class DragObject : MonoBehaviour {
 
     private float dist;
     private Vector3 v3Offset;
     private Plane plane;
     private bool ObjectMouseDown = false;
     public GameObject linkedObject;
     
     void OnMouseDown() {
         plane.SetNormalAndPosition(Camera.main.transform.forward, transform.position);
         Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
         float dist;
         plane.Raycast (ray, out dist);
         v3Offset = transform.position - ray.GetPoint (dist);     
         ObjectMouseDown = true;
     }
     
     void OnMouseDrag() {
         if (ObjectMouseDown == true){
             Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
             float dist;
             plane.Raycast (ray, out dist);
             Vector3 v3Pos = ray.GetPoint (dist);
             v3Pos.z = gameObject.transform.position.z;
             v3Offset.z = 0;
             transform.position = v3Pos + v3Offset;
 
             if (linkedObject != null){ 
                 linkedObject.transform.position = v3Pos + v3Offset;
             }
         }
     }
 
     void OnMouseOut() {
         ObjectMouseDown = false;
     }
 
     }
 
