    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.DirectoryServices;
    
    namespace WindowsFormsApplication15
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                if (IsAuthenticated("YOUR DOMAIN", "USERNAME", "PASSWORD") == false)
                {
                    // not exist in active directory!
                }
                else
                {
                    // user is exist in active directory
                }
            }
    
            private string _path { get; set; }
            private string _filterAttribute { get; set; }
            public bool IsAuthenticated(string domain, string username, string pwd)
            {
                string domainAndUsername = domain + "\\" + username;
                DirectoryEntry entry = new DirectoryEntry(_path, domainAndUsername, pwd);
                try
                {
                    object obj = entry.NativeObject;
                    DirectorySearcher search = new DirectorySearcher(entry);
                    search.Filter = "(SAMAccountName=" + username + ")";
                    search.PropertiesToLoad.Add("cn");
                    SearchResult result = search.FindOne();
                    if ((result == null))
                    {
                        return false;
                    }
    
                    _path = result.Path;
                    _filterAttribute =  result.Properties["cn"][0].ToString();
    
                }
                catch (Exception ex)
                {
                    return false;
                }
    
                return true;
            }
        }
    }
