    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class CameraZoom : MonoBehaviour {
    public float zoom = 10F;
    void Update () {
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && zoom > 9)
        {
            zoom -= 1;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && zoom < 101)
        {
            zoom += 1;
        }
         Camera cam = GetComponent<Camera>();
         RaycastHit hit;
         Ray ray = cam.ScreenPointToRay(Input.mousePosition);
         Vector3 targetPos;
         if (Physics.Raycast(ray , out hit))
         {
			targetPos = hit.point;
         }
		Camera cam = GetComponent<Camera>();
        cam.orthographicSize = zoom;
        cam.transform.position += (targetPos - transform.position) / 5f;
      }
    }
