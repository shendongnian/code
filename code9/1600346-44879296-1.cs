        using UnityEngine;
        using System.Collections;
        
        public class KittyUIController : MonoBehaviour
        {
            public GameObject m_kitten;
        	public GameObject yourOtherModel; // could be prefab
            private TangoPointCloud m_pointCloud;
        	private GameObject createdKitten;
        
            void Start()
            {
                m_pointCloud = FindObjectOfType<TangoPointCloud>();
            }
        
            void Update ()
            {
                if (Input.touchCount == 1)
                {
                    // Trigger place kitten function when single touch ended.
                    Touch t = Input.GetTouch(0);
                    if (t.phase == TouchPhase.Ended)
                    {
                        PlaceKitten(t.position);
                    }
                }
            }
        	//This method will disable the kitten and instantiate or place a GameObject on the same spot.
        	public void ReplaceKitten()
        	{
        		GameObject modelToReplace;
        		//Do this only if you will pass a Prefab to this Script
        		modelToReplace = Instantiate(yourOtherModel, planeCenter);
        		//Set your new object at the same coordinates and reset position
        		modelToReplace.transform.parent = m_kitten;
        		modelToReplace.transform = new Vector3(0,0,0);
        		//Disable kitten
        		m_kitten.SetActive(false);
        	}
        
            void PlaceKitten(Vector2 touchPosition)
            {
                // Find the plane.
                Camera cam = Camera.main;
                Vector3 planeCenter;
                Plane plane;
                if (!m_pointCloud.FindPlane(cam, touchPosition, out planeCenter, out plane))
                {
                    Debug.Log("cannot find plane.");
                    return;
                }
        
                // Place kitten on the surface, and make it always face the camera.
                if (Vector3.Angle(plane.normal, Vector3.up) < 30.0f)
                {
                    Vector3 up = plane.normal;
                    Vector3 right = Vector3.Cross(plane.normal, cam.transform.forward).normalized;
                    Vector3 forward = Vector3.Cross(right, plane.normal).normalized;
                    createdKitten = Instantiate(m_kitten, planeCenter, Quaternion.LookRotation(forward, up));
                }
                else
                {
                    Debug.Log("surface is too steep for kitten to stand on.");
                }
            }
        }
