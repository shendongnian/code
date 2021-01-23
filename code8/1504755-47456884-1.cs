    using UnityEngine;
    using System.Collections;
    using UnityEngine.SceneManagement; // The new load level needs this
    public class ExampleClass : MonoBehaviour
    {
        void OnMouseDown()
        {
            // Edit:
            // Application.LoadLevel("SomeLevel");
            // Application.LoadLevel() is depreciating but still works
         
             SceneManager.LoadScene("SomeLevel"); // The new way to load levels
        }
    }
