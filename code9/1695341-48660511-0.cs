    using UnityEngine;
    class Monster : MonoBehaviour {
        public Vector3 endPosition;
        public float speed = 1f; // The monster will move a one unity per second
            public void Update(){
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, endPosition, step);
        }
       
