    static void Main(string[] args)
        {
            
            //Start IE with google url
            Process.Start("iexplore", "www.google.com");
            //Wait for page load. This can be avoided but that will extra code
            Thread.Sleep(5000);
            InternetExplorer IEGoogle=null;
            HTMLDocument htmlGoogle;
            //Getting InternetExplorer from all open windows
            SHDocVw.ShellWindows shellWindows = new SHDocVw.ShellWindows(); shellWindows = new SHDocVw.ShellWindows();
            foreach (InternetExplorer browser in shellWindows )
            {
                if(browser.LocationURL.ToLower().Contains("www.google.com"))
                {
                    IEGoogle = browser;
                    break;
                }
            }
            if(IEGoogle!=null)
            {
                //Get HTML content in HTMLDocument from InternetExplorer object
                htmlGoogle = IEGoogle.Document;
                //Open google.com and Using Developer tools(Press F12) and see the details of searchbox on google.com. I have found that name property of searchbox is unique.
                HTMLInputElement searchbox = htmlGoogle.getElementsByName("q").item() as HTMLInputElement;
                
                if (searchbox != null)
                {
                    searchbox.value = "First Way Oxford Library";
                }
                Console.ReadLine();
                //Alternate way
                var inputElements = htmlGoogle.getElementsByTagName("input");
                if(inputElements!=null)
                {
                    foreach(HTMLInputElement googleSearch in inputElements)
                    {
                        if (googleSearch != null)
                        {
                            if (googleSearch.name != null)
                            {
                                if (googleSearch.name.Equals("q"))
                                {
                                    googleSearch.value = " Second Way Oxford Library";
                                }
                            }
                        }
                        
                    }
                }
                 
            }
            
        }
