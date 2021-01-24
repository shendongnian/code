    public class Raycaster : MonoBehaviour
     {
         private bool hitting = false;
         private GameObject hitObject;
         
         void Update()
         {
             RaycastHit hit;
             if (Physics.Raycast(transform.position, transform.forward, out hit))
             {
                if(hit.transform.tag == "MyGameObject")
                {
                    GameObject go = hit.transform.gameobject ;
                    
                    // If no registred hitobject => Entering
                    if( hitObject == null )
                    {
                        go.SendMessage ("OnHitEnter"); 
                    }
                    // If hit object is the same as the registered one => Stay
                    else if( hitObject.GetInstanceID() == go.GetInstanceID() )
                    {
                        hitObject.SendMessage( "OnHitStay" );
                    }
                    // If new object hit => Exit last + Enter new
                    else
                    {
                        hitObject.SendMessage( "OnHitExit" );
                        go.SendMessage ("OnHitEnter");
                    }
                    
                    hitting = true ;
                    hitObject = go ;
                } 
             }
             // No object hit => Exit last one
             else if( hitting )
             {
                hitObject.SendMessage( "OnHitExit" );
                hitting = false ;
                hitObject = null ;
             }
         }
     }
