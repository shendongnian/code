    using UnityEngine;
    
    internal class HandModel : MonoBehaviour
    {
    }
    
    internal class MyClass : MonoBehaviour
    {
        private HandModel TryGetHandVersion1(Collider other)
        {
            return other.GetComponentInParent<HandModel>();
        }
    
        private HandModel TryGetHandVersion2(Collider other)
        {
            var current = other.transform;
            while (current != null)
            {
                var handModel = current.GetComponent<HandModel>();
                if (handModel != null)
                    return handModel;
    
                current = current.parent;
            }
            return null;
        }
    
        private void OnTriggerEnter(Collider other)
        {
            var isHand = TryGetHandVersion1(other) != null;
        }
    }
