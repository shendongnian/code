    using System.Data;
    using System.Diagnostics;
    using System.Linq;
    using System.ServiceProcess;
    using System.Text;
    using System.Threading.Tasks;
    using System.DirectoryServices;
    using System.DirectoryServices.AccountManagement;
    using System.IO;
    using IWshRuntimeLibrary;
    using System.Reflection;
    using Shell32;
    using System.Net.NetworkInformation;
    using System.Threading;
    using System.Management;
    using System.Security.Principal;
            if (!Directory.Exists(@"H:\"))
                {
                    //ping Hdrive server
                    try
                    {   //find current domain controller
                        using (PrincipalContext context = new PrincipalContext(ContextType.Domain))
                        {
                            string controller = context.ConnectedServer;
                            //ping current domain controller
                            Ping ping = new Ping();
                            PingReply pingReply = ping.Send(controller);
                            if (pingReply.Status == IPStatus.Success)
                            {
                                try
                                {
                                    //get current username
                                    String username = Environment.UserName;
                                    
                                    //Lookup current username in AD
                                    DirectoryEntry myLdapConnection = createDirectoryEntry();
                                    DirectorySearcher search = new DirectorySearcher(myLdapConnection);
                                    search.Filter = "(cn=" + username + ")";
                                    //Search for User's Home Directory 
                                    string[] requiredProperties = new string[] { "homeDirectory" };
                                    foreach (String property in requiredProperties)
                                        search.PropertiesToLoad.Add(property);
                                    SearchResult result = search.FindOne();
                                    // If home directory info is not blank
                                    if (result != null)
                                    {
                                        //pass the homedirectory path into a variable
                                        string path = "";
                                        foreach (String property in requiredProperties)
                                            foreach (Object myCollection in result.Properties[property])
                                                path = (myCollection.ToString());
                                        //map Hdrive (non persistent map)
                                        System.Diagnostics.Process.Start("net.exe", "use /persistent:NO H: " + path);
                                        //create a desktop shortcut to Hdrive
                                        var wsh = new IWshShell_Class();
                                        IWshRuntimeLibrary.IWshShortcut shortcut = wsh.CreateShortcut(
                                        Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\H Drive.lnk") as IWshRuntimeLibrary.IWshShortcut;
                                        shortcut.TargetPath = path;
                                        shortcut.Save();
                                    }
                                }
                                catch (Exception)
                                {
                                    //do nothing
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        //do nothing
                    }
                }
        }
        public static DirectoryEntry createDirectoryEntry()
        {
            // create and return new LDAP connection 
            DirectoryEntry ldapConnection = new DirectoryEntry("mydomain.com");
            ldapConnection.Path = "LDAP://mydomain.com/OU=Users,DC=mydomain,DC=Com";
            ldapConnection.AuthenticationType = AuthenticationTypes.Secure;
            return ldapConnection;
        }
    
