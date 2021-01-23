    using System.IO
    namespace {
         {
    public partial class TestForm:Form{
    RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run","true");
    public TestForm(){
    reg.SetValue("MyApp",Application.ExecutablePath.ToString());
    InitializeComponent();
                     }
                } 
          }
    }
