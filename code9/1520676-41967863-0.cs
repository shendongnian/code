    private HashSet<Enemy> list = null;
    private void Awake(){this.list = new HashSet<Enemy>();}
	void OnTriggerEnter(Collider col){
         Enemy enemy = col.transform.GetComponent<Enemy>();
         print(enemy); // this occurs
         if(enemy != null && this.list.Contains(enemy) == true)
         { 
         	print(enemy); // this never occurs
             this.list.Remove(enemy);  
         } 
		}
		}
	void hit(){      
        print("hit"); // this occurs
   
		foreach(Enemy enemy in this.list)
         {   // this never occurs
            enemy.GetComponent<health>().DealDamage(damage); 
         }
