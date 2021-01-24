    using System;
    using System.Management.Automation;
    using System.Web.UI.WebControls;
    
    namespace WPS_Test2
    {
        public partial class SCCM_info : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
    
            protected void ExecuteCode_Click(object sender, EventArgs e)
            {
                // Initialize PowerShell engine
                var shell = PowerShell.Create();
    
                // Attention: No not use spaces!!! Script may cause problems or wont work at all.
                string pathToWPS = @"C:\Users\sudo\Desktop\WPS_projects\WPS_Test2\WPS_Test2\zzz_wps_scripts\SCCM_info.ps1";
    
                // Add the script to the PowerShell object
                shell.AddCommand(pathToWPS);
    
                // Add some arguments / params
                shell.AddParameter("sccm_server", SCCM_server.Text);
    
                // Execute the script
                var results = shell.Invoke();
    
                LabelSelectedSCCMsrv.Text = "selected SCCM server: " + SCCM_server.Text;
    
                foreach (var name in results[0].Members)
                {
                    if (FindControl("lbl" + name.Name) != null)
                    {
                        // Find label with the same name as the current property and display the value
                        // Encode the string in HTML (prevent security issue with 'dangerous' caracters like < >
                        if (name.Value != null)
                        {
                            (FindControl("lbl" + name.Name) as Label).Text = Server.HtmlEncode(name.Value.ToString());
                        }
                    }
                }
            }
        }
    }
