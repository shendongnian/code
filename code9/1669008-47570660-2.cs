    using UnityEngine;
    
    public class TrignometryTest : MonoBehaviour 
    {
        public float range;
        [Range(5,170)]
        public float angle;
    
    	Vector3 size = Vector3.one;
    
        Vector3[] GetFOVPoints(float _range, float _angleInDegrees)
        {
            Vector3 rightPoint, leftPoint;
            float halfAngle = _angleInDegrees/2;
    
            rightPoint = new Vector3(_range * Mathf.Tan(halfAngle * Mathf.Deg2Rad), _range, 0);
            leftPoint = new Vector3(-_range * Mathf.Tan(halfAngle * Mathf.Deg2Rad), _range, 0);
    
            Vector3[] points =  { transform.position, leftPoint, rightPoint};
            return points;
        }
    
        void OnDrawGizmos()
        {
            var points = GetFOVPoints(range, angle);
            
            Gizmos.DrawCube(points[0], size);
            Gizmos.DrawCube(points[1], size);
            Gizmos.DrawCube(points[2],size);
    
            Gizmos.DrawLine(points[0], points[1]);
            Gizmos.DrawLine(points[0], points[2]);
            Gizmos.DrawLine(points[1], points[2]);
            Gizmos.DrawLine(points[0],Vector3.up * range);
        }
    
    }
