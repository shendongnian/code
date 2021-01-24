    using UnityEngine;
    using System.Collections;
    public class AddComponentExample : MonoBehaviour
    {
       void Start( )
       {
          SphereCollider sc = gameObject.AddComponent<SphereCollider> as SphereCollider;
       }
    }
