     public static void Main(string[] args)
        {
            Load().Wait();
            BuildWebHost(args).Run();
        }
     
     public static async Task Load()
        {
            //Set directory where app should look for FFmpeg 
            FFmpeg.ExecutablesPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FFmpeg");
            //Get latest version of FFmpeg. It's great idea if you don't know if you had installed FFmpeg.
            await FFmpeg.GetLatestVersion();
        }
