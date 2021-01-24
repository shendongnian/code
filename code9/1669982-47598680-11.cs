     public async Task CreateUser()
        {
          var task =  Task.Factory.SartNew(()=> GetUserOrder());
           await GetUserDetails();   
           if(!task.IsCompleted)
           task.Wait(); 
        }
