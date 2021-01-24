    public void Main()
    {
      List<PlayerData> playerdata = new List<PlayerData>
      {
        new PlayerData
        {
           isSelected = true,
           distance = 3,
           nickname = "First",
          
        },
        new PlayerData
        {
            isSelected = true,
            distance = 3,
             nickname = "Second",
        },
        new PlayerData
        {
           isSelected = true,
           distance = 3,
           nickname = "Third",
        }
      };
    
      PlayerData player = playerdata.Find(x => x.isSelected);
      Console.WriteLine(player);
      
    }
    public class BaseData 
    {
       public bool isSelected;
       public int distance;
    }
    public class PlayerData: BaseData 
    {
       public string nickname;
       public override string ToString() { return this.nickname;}
    }
