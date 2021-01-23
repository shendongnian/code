    using System.Linq;
    using UnityEngine;
    
    public class Tower : MonoBehaviour
    {
        private void Update()
        {
            var objects = GameObject.FindGameObjectsWithTag("Player");
            if (!objects.Any())
                return;
    
            var target = objects.First();
            if (target == null)
                return;
    
            var p1 = transform.position;
            var p2 = target.transform.position;
            var position = new Vector3(p2.x, p1.y, p2.z); // does not bend to target
            transform.LookAt(position);
        }
    }
