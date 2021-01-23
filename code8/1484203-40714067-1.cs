    public Task<string> GetData(int id)
    {
         return Task.Run() => 
         {
             Task<string> inp =  CommonMethod(id);
             return inp; 
         }
    }
