    public class UserVm { 
       public UserVm (Users model)
       {
           Name = model.Name;
           Age = model.Age;
           Location = model.Location;
       }
       public string Name{ get; set; }
       public int Age { get; set; }
       public string Location { get; set; }
    }
