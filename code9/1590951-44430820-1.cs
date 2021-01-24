    public class PlayerController_Jumper : MonoBehaviour, IPlayerCharacter 
    {
        // Does a jump
        void DoActionA() 
        {
            rigidbody.AddVelocity(Vector3.Up, 100.0f);
        }
    } 
