    using System.Diagnostics;    
    Stopwatch sw = new Stopwatch();
    int timeout = 60; // 60 seconds
    sw.Start(); // Use Restart for the next element, to reset the time to 0 first.
    var element = webBrowser1.Document.GetElementById("login_login_button");
    while(element == null && sw.Elapsed.TotalSeconds < timeout)
    {
        Thread.Sleep(2000);
        element = webBrowser1.Document.GetElementById("login_login_button");
    }
    sw.Stop();
    if(element!=null)
    {
        element.InvokeMember("Click"); 
    }
    ...
    // if success, repeat with similar pattern for the next element
    // if you still can't find the element, you'd better quit what you are trying to do
