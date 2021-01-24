    using UnityEngine;
    
    public class NewBehaviourScript : MonoBehaviour
    {
        private Camera _camera;
        private GameObject _find;
    
        private void OnEnable()
        {
            _find = GameObject.Find("New Sprite");
            _camera = Camera.main;
        }
    
        private void Update()
        {
            // find the vector between cannon and mouse position
            var p1 = _camera.ScreenToViewportPoint(Input.mousePosition);
            var p2 = _camera.WorldToViewportPoint(_find.transform.position);
            var p3 = p2 - p1;
    
            // rotate cannon to mouse position
            var angle = Mathf.Atan2(p3.y, p3.x) * Mathf.Rad2Deg;
            _find.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    
            // throw a projectile on mouse down
            if (Input.GetMouseButtonDown(0))
            {
                var clone = Instantiate(_find);
    
                var rb = clone.AddComponent<Rigidbody2D>();
                rb.gravityScale = 0;
    
                var force = clone.AddComponent<ConstantForce2D>();
                force.relativeForce = Vector2.left * 5.0f;
            }
        }
    }
