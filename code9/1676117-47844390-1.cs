    using UnityEngine;
    public class sExample : MonoBehaviour
    {
      [SerializeField] public GameObject gameObj;
      public void serializeUse()
      {
        //Do something with gameObj
      }
    }
    public class serializeEx : NetworkBehaviour
    {
      public void Update()
      {
        If (!isLocalPlayer)
        {
          sExample.serializeUse()
        }
      }
    }
