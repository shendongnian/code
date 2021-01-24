    public static string GetCurrentMethod([CallingMemberName] string method = "")
    {
         return method;
    }
    public async Task<int> GetNumber(long ID)
    {
       int result = await Task.Run(() => { return 20; });
       Console.WriteLine(GetCurrentMethod()); // prints GetNumber
       return result;
    }
