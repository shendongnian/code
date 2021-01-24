    using UnityEngine;
    
    public class ServiceManager : MonoBehaviour
    {
        public static Transform T { get; private set; }
    
        void Start()
        {
            T = transform;
        }
    
        public T Provide<T>() where T : MonoBehaviour
        {
            return ServiceMap<T>.service; // no cast required
        }
    }
    
    static class ServiceMap<T> where T : MonoBehaviour
    {
        public static readonly T service;
    
        static ServiceMap()
        {
            // Create service
            GameObject serviceObject = new GameObject(typeof(T).Name);
            serviceObject.transform.SetParent(ServiceManager.T); // make service GO our child
            service = serviceObject.AddComponent<T>(); // attach service to GO
        }
    }
