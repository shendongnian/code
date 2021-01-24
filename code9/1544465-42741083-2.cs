    public class EnemyAI_Basic : MonoBehaviour
    {
        //your other variables
        public delegate void EnemyDies();  //declare the method types that can be registered to the event
        public event EnemyDies onEnemyDeath; //declare event, using the delegate for the method type
        //other methods here
        private void OnEnable()
        {
            //must be the same method type as the event, the compiler will let you know if it isn't
            onEnemyDeath += Death;
            onEnemyDeath += ActivateRagdoll;            
        }
        private void OnDisable()
        {
            onEnemyDeath -= Death;
            onEnemyDeath -= ActivateRagdoll;
        }
        //other things here
        //doesn't have to be public, just in case you want a bullet to kill the enemy
        public void KillAi()
        {
            //checking for null basically says: is anybody registered? If not, nothing to invoke. 
            //It will get upset if you try and invoke an event without any registered methods, hence the check.
            if(onEnemyDeath != null)
            {
                onEnemyDeath();
            }
        }
        void Death()
        {
           Dead = true;
           Alive = false;
           capsuleCollider.isTrigger = true;
           anim.SetTrigger("Dead");
           //ActivateRagdoll();   You don't have to manually call this now, invoking the event will call it for you.
           //Registration order is important, me thinks. Experiment :)
           Destroy(gameObject, 4f);
        }
    }
