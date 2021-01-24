     public class Raycaster : MonoBehaviour {
         private bool hitting = false;
         private GameObject hitObject;
         
         void Update() {
             RaycastHit hit;
             if (Physics.Raycast(transform.position, transform.forward, out hit))
             {
                if(hit.transform.tag == "MyGameObject")
                {
                    if( !hitting )
                    {
                        hit.transform.SendMessage ("OnHitEnter");
                    }
                    else
                    {
                        hitObject.SendMessage( "OnHitStay" );
                    }
                    hitting = true ;
                    hitObject = hit.transform.gameobject ;
                } 
             }
             else if( hitting )
             {
                hitObject.SendMessage( "OnHitExit" );
                hitting = false ;
                hitObject = null ;
             }
         }
     }
