    public class MTBL_DataContainer
    {
    	public int ID { get; set; }
    	public string Manager_Name { get; set; }
    	public string Nationality  { get; set; }
    	public string Team { get; set; }
    	public int Trophies { get; set; }    
    }
    var PopulateManagers = from m in db.ManagerTBLs
                   where m.ManagerName != null
                   orderby m.TeamName descending
                   select new MTBL_DataContainer
                   {
                       ID = m.Id,
                       Manager_Name = m.ManagerName,
                       Nationality = m.ManagerNationality,
                       Team = m.TeamName,
                       Trophies = m.TrophyCount,
                   };
    lbxManagerDisplay.ItemsSource = PopulateManagers.ToList();
