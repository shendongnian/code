    public class PlayerAttack:MonoBehaviour
    {
        private HashSet<Enemy> list = null;
        private void Awake(){ this.list = new HashSet<Enemy>(); }
        private void OnTriggerEnter(Collider col)
        {
             Enemy enemy = col.transform.GetComponent<Enemy>();
             if(enemy != null)
             {
                 this.list.Add(enemy);  
             } 
        }
        private void OnTriggerExit(Collider col)
        {
             Enemy enemy = col.transform.GetComponent<Enemy>();
             if(enemy != null && this.list.Contains(enemy) == true)
             { 
                 this.list.Remove(enemy);  
             } 
        }
        public void OnAttack()
        {
             foreach(Enemy enemy in this.list)
             { 
                enemy.GetComponent<Health>.DealDamage(damage); 
             }
        }
    }
