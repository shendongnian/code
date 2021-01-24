            SHDocVw.ShellWindows shellWindows = new SHDocVw.ShellWindows();
            Console.WriteLine("Starting Search\n\n\n");
            foreach (SHDocVw.InternetExplorer ie in shellWindows)
            {
                if (ie.LocationURL.Contains("aavtrain"))
                {
                    Console.WriteLine(ie.LocationURL);
                    Console.WriteLine("\n\n\n\n");
                    Console.WriteLine("FOUND!\n");
                    mshtml.HTMLDocument document = ie.Document;
                    mshtml.IHTMLElementCollection elCol = document.getElementsByName("user_name");
                    mshtml.IHTMLElementCollection elCol2 = document.getElementsByName("password");
                    mshtml.IHTMLElementCollection elCol3 = document.getElementsByName("Submit");
                    
                    Console.WriteLine("AutofillPassword");
                    foreach (mshtml.IHTMLInputElement i in elCol)
                    {
                        i.defaultValue = "John";
                    }
                    foreach (mshtml.IHTMLInputElement i in elCol2)
                    {
                        i.defaultValue = "Password";
                    }
                    Console.WriteLine("Will Click Button in 2 seconds");
                    Thread.Sleep(2000);
                    foreach (mshtml.HTMLInputButtonElement i in elCol3)
                    {
                        
                        i.click();
                    }
                    
                }
            }
            Console.WriteLine("Finished");
