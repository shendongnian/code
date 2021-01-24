        integer I = 0;
        do
        {
        I=1
    
    foreach (KeyValuePair<IntPtr, string> window in OpenWindowGetter.GetOpenWindows())
                {
                    string title = window.Value;
    
                    if (errorArray.Any(title.Equals))
                    {
                        i++;                                                       
                        System.Console.WriteLine("\nFound {0} of 9 error messages\n", i);// 
                        int iHandle = FindWindow(null, title);
                        SendMessage(iHandle, WM_SYSCOMMAND, SC_CLOSE, 0);
                        System.Console.WriteLine("{0} pop up closed\n", title);
                        Thread.Sleep(5000);
                    }
                    else
                    {
                       I=0
                       thread.Sleep(60000);
                       //wait for a 60 seconds , then 
                    }
    
    
                }
    } while (I=0)
