        bool finished=false;
        do
        {
        finished=false;
    
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
                        finished=true;
                    }
                    else
                    {
                       thread.Sleep(60000);
                       //wait for a 60 seconds , then 
                    }
    
    
                }
    } while (finished==false)
