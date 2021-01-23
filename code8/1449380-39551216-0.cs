    using UnityEngine;
    using System.Threading;
    
    public class Card : MonoBehaviour
    {
        public Card()
        {
            Debug.Log("Constructor Thread ID: " + Thread.CurrentThread.ManagedThreadId);
        }
    
        void Start()
        {
            Debug.Log("Start() function Thread ID: " + Thread.CurrentThread.ManagedThreadId);
        }
        // Update is called once per frame
        void Update()
        {
            Debug.Log("Update() function Thread ID: " + Thread.CurrentThread.ManagedThreadId);
        }
    }
