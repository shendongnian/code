    using UnityEngine;
    public class Question : MonoBehaviour {
        public Vector3 startPosition = Vector3.left * 5;
        public Vector3 endPosition = Vector3.right * 5;
    
        void OnDrawGizmos() {
            Gizmos.color = Color.blue;
            Gizmos.DrawCube(startPosition, Vector3.one);
            Gizmos.DrawSphere(endPosition, 1);
    
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(startPosition, endPosition);
    
            var mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            var mousePos = mouseRay.GetPoint(Mathf.Abs(Camera.main.transform.position.z));
            var pointOnLine = ClosestPointOnLine(startPosition, endPosition, mousePos, true);
    
            Gizmos.color = Color.black;
            Gizmos.DrawLine(startPosition, pointOnLine);
        }
    
        /// <summary> Returns the point nearest point to the [point] on the line given by start and end points, [lineStart] and [lineEnd]</summary>
        /// <param name="clampLine"> If true, the returned point will be on the line segment, rather than the line. </param>
        public static Vector3 ClosestPointOnLine(Vector3 lineStart, Vector3 lineEnd, Vector3 point, bool clampLine = false) {
            var dif = lineEnd - lineStart;
            var direction = Vector3.Normalize(dif);
            float closestPoint = Vector3.Dot((point - lineStart), direction) / dif.magnitude;
            if (clampLine)
                closestPoint = Mathf.Clamp(closestPoint, 0, 1);
            return lineStart + (closestPoint * dif);
        }
    }
