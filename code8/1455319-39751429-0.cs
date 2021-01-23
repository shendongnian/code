    var sessionList = Process.Start("cmd", "c:\>query session").ToList();
    sessionList = sessionList.Where(x => x.Username == "Piet")
    foreach( var item in sessionList)
    {
     console.WriteLine(item.id)
    }
     
