    try
    {
       // your code
    }
    catch(Win32Exception w) 
    {
       Console.WriteLine(w.Message);
       Console.WriteLine(w.ErrorCode.ToString());
       Console.WriteLine(w.NativeErrorCode.ToString());
       Console.WriteLine(w.StackTrace);
       Console.WriteLine(w.Source);
       Exception e= w.GetBaseException();
       Console.WriteLine(e.Message);
    }
