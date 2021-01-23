    using Microsoft.Office.Interop.Outlook;
    using static System.Console;
    
    namespace OutlookDriverProgram
    {
        class Program
        {
            static void Main(string[] args)
            {
                Application app = new Application();
                NameSpace ns = app.GetNamespace("MAPI");
                Stores stores = ns.Stores;
    
                foreach (Store store in stores)
                {
                    //Uncomment next line to see the folder names
                    //WriteLine("Folder name = {0}", store.DisplayName);
                    if (store.DisplayName.Equals("YOURFOLDERNAME"))
                    {
       
                        MAPIFolder YOURFOLDERNAME = store.GetRootFolder();
    
                        foreach (Folder subF in YOURFOLDERNAME.Folders)
                        {
                          
                            if (subF.Name.Equals("Inbox"))
                            {
                                foreach (MailItem email in subF.Items)
                                {
                                    WriteLine("Email subject = {0}", email.Subject);
                                }
    
                            }
    
                        }
                    }
    
                }
            }
    
        }
    }
