    public class DamageStatus : MonoBehaviour
    {
        bool detectedBefore = false;
    
        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Target"))
            {
                //Exit if we have already done some damage
                if (detectedBefore)
                {
                    return;
                }
    
                //Set the other detectedBefore variable to true
                DamageStatus dmStat = other.gameObject.GetComponent<DamageStatus>();
                if (dmStat)
                {
                    dmStat.detectedBefore = true;
                }
    
                // Put damage/or code to run once below
    
            }
        }
    
        void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.tag == "Target")
            {
                //Reset on exit?
                detectedBefore = false;
            }
        }
    }
