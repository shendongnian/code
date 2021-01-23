    public class Profile
    {
      private readonly INewInterface _user;
      public Profile(INewInterface user)
      {
          this._user = user;
      }
    
      public void DisplayTask()
      {
        _user.GetTasks();
      }
      
      public string MyRole()
      {
        return _user.GetRole();
      }
      public void MySpecificTask()
      {
        _user.EmployeeSpecificTask();
      }
      
      public void Greetings()
      {
        Console.WriteLine("Hello! Welcome to profile.");
      }
    }
