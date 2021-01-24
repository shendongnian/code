    string Name = Path.GetFileNameWithoutExtension(loadPath);
    Name = string.Format("{0}_{1}_{2}.csv", Name, SessionUtil.LoginUser.UserId, DateTime.Now.ToString("ddMMMyyyyHHmm"));
    string MovePath = System.IO.Path.Combine(Output, Name);
    if (!System.IO.Directory.Exists(Output))
    {
       System.IO.Directory.CreateDirectory(Output);
    }
    System.IO.File.Move(loadPath, MovePath);
    System.Threading.Thread.Sleep(250); // sleeps the thread for 250 msecs
