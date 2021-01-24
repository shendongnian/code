    public class Test : MonoBehaviour
    {
    
        void OnEnable()
        {
            EventManager.StartListening("OnPlayerTeleport", TeleportPlayer);
        }
    
        void OnDisable()
        {
            EventManager.StopListening("OnPlayerTeleport", TeleportPlayer);
        }
    
        void Update()
        {
            if (Input.GetButtonDown("Teleport"))
            {
                EventManager.TriggerEvent("OnPlayerTeleport", 5);
            }
        }
    
        void TeleportPlayer(float h)
        {
            float yPos = transform.position.y;
            yPos += h;
            transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
        }
    }
