    using UnityEngine;
    using System.Collections;
    
    public class TestController : MonoBehaviour
    {
        public float mainThrust = 100;
        private Vector3 cameraOffset = new Vector3(0f, 0f, 150f);
        private new Rigidbody rigidbody;
    
        private Vector3 tmpV1 = new Vector3(0f, 0f, 0f);
        private Vector3 tmpV2 = new Vector3(0f, 0f, 0f);
    
        // Draw debug cross at camera position
        private void drawX()
        {
            tmpV1.x = Camera.main.transform.position.x - 10f;
            tmpV1.y = Camera.main.transform.position.y;
            tmpV2.x = Camera.main.transform.position.x + 10f;
            tmpV2.y = Camera.main.transform.position.y;
            Debug.DrawLine(tmpV1, tmpV2, Color.red);
            tmpV1.x = Camera.main.transform.position.x;
            tmpV1.y = Camera.main.transform.position.y - 10f;
            tmpV2.x = Camera.main.transform.position.x;
            tmpV2.y = Camera.main.transform.position.y + 10f;
            Debug.DrawLine(tmpV1, tmpV2, Color.red);
        }
    
        void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
        }
    
        void FixedUpdate()
        {
            float axisVertical = Input.GetAxis("Vertical");
            // impulse force in Newton
            Vector2 force = new Vector2(0f, axisVertical) * mainThrust * Time.fixedDeltaTime;
            rigidbody.AddRelativeForce(force, ForceMode.Impulse);
        }
    
        void LateUpdate()
        {
            Camera.main.transform.position = rigidbody.transform.position - cameraOffset;
            drawX();
            Debug.Log("camPos: " + Camera.main.transform.position + " - rbPos: " + rigidbody.transform.position);
        }
    }
