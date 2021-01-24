    using UnityEngine;
    using System.Collections;
    
    public class PlayerTeleporter : MonoBehaviour
    {
    
        bool shooting = false;
        
        void Update()
        {
    
            if (Input.GetButtonDown("Fire1"))
            {
                shooting = true;
            }
    
        }
    
        void FixedUpdate()
        {
            if (shooting)
            {
                shooting = false;
    
                RaycastHit hit;
    // you are casting a ray in front of your camera wich hits the first collider in its path
                if (Physics.Raycast(transform.position, transform.forward, out hit, 100f))
                {
    // normally you shouldn't teleport directly into the trget object
                    transform.position = hit.transform.position;
                }
            }
        }
    }
