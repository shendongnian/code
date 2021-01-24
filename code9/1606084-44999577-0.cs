    using System.Collections.Generic;
     using UnityEngine;
     
     [RequireComponent(typeof(LineRenderer))]
     public class LineRendererTest : MonoBehaviour
     {
         List<Vector3> linePoints = new List<Vector3>();
         LineRenderer lineRenderer;
         public float startWidth = 1.0f;
         public float endWidth = 1.0f;
         public float threshold = 0.001f;
         Camera thisCamera;
         int lineCount = 0;
     
         Vector3 lastPos = Vector3.one * float.MaxValue;
         
         
         void Awake()
         {
             thisCamera = Camera.main;
             lineRenderer = GetComponent<LineRenderer>();
         }
     
         void Update()
         {
             Vector3 mousePos = Input.mousePosition;
             mousePos.z = thisCamera.nearClipPlane;
             Vector3 mouseWorld = thisCamera.ScreenToWorldPoint(mousePos);
             
             float dist = Vector3.Distance(lastPos, mouseWorld);
             if(dist <= threshold)
                 return;
             
             lastPos = mouseWorld;
             if(linePoints == null)
                 linePoints = new List<Vector3>();
             linePoints.Add(mouseWorld);
             
             UpdateLine();
         }
     
     
         void UpdateLine()
         {
             lineRenderer.SetWidth(startWidth, endWidth);
             lineRenderer.SetVertexCount(linePoints.Count);
     
             for(int i = lineCount; i < linePoints.Count; i++)
             {
                 lineRenderer.SetPosition(i, linePoints[i]);
             }
             lineCount = linePoints.Count;
         }
