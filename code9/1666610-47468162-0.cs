    List<Enemy> addressList = new List<Enemy>();
        
    for (int i = 0; i < 10; i++)
    {
       Enemy enemy= new Enemy() { name= "bad people",damage= "15"}
       addressList.Add(enemy);
    }
       
    public class Enemy 
    {
        public string name{ get; set; }
    
        public string damage{ get; set; }
    }
