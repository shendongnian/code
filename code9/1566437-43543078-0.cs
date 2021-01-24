    using UnityEngine;
    using System.Collections;
    
    public class ExampleClass : MonoBehaviour
    {
        void Update()
        {
            if (transform.hasChanged)
            {
                print("The transform has changed!");
                transform.hasChanged = false;
            }
        }
    }
