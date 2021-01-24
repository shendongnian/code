    using UnityEngine;
    
    public class TrignometryTest : MonoBehaviour 
    {
        public float range;
        [Range(5,170)]
        public float angle;
    
        Vector3 rightPoint, leftPoint;
        float halfAngle;
    
        void OnDrawGizmos()
        {
            Vector3 size = Vector3.one * 0.1f;
            Gizmos.DrawCube(transform.position,size);
    
            halfAngle = angle / 2;
    
            rightPoint = new Vector3(range *  Mathf.Tan(halfAngle * Mathf.Deg2Rad), range, 0);
            leftPoint = new Vector3(-range *  Mathf.Tan(halfAngle * Mathf.Deg2Rad ),range,0);
    
            Gizmos.DrawCube(rightPoint, size);
            Gizmos.DrawCube(leftPoint, size);
    
            Gizmos.DrawLine(transform.position, rightPoint);
            Gizmos.DrawLine(transform.position, leftPoint);
            Gizmos.DrawLine(leftPoint, rightPoint);
    
            Gizmos.DrawLine(transform.position,Vector3.up * range);
        }
    
    }
