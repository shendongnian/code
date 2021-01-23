    private static async Task<bool> IsFileAvailable(FileInfo file)
        {
            //Your Code
        }
    public static async Task DoStuff()
        {
            await Task.Run(() =>
            {
                LongRunningOperation();
            });   
        }
    static void Main()
        {
           DoStuff();
           //Other Codes
        }
