    using Microsoft.VisualBasic.ApplicationServices;
    
    static Form1 MainForm;
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        MainForm = new Form1();
        SingleInstanceApplication.Run(MainForm,  NewInstanceHandler);
    }
    
    public static void NewInstanceHandler(object sender, StartupNextInstanceEventArgs e)
    {   
        // anything u need run on old instance
        // MainForm.Hide();
        MainForm.Show();
        MainForm.WindowState = FormWindowState.Normal;
        e.BringToForeground = true;
    }
    
    
    public class SingleInstanceApplication : WindowsFormsApplicationBase
    {
         private SingleInstanceApplication()
         {
            base.IsSingleInstance = true;
         }
         public static void Run(Form f, StartupNextInstanceEventHandler startupHandler)
         {
            SingleInstanceApplication app = new SingleInstanceApplication();
            app.MainForm = f;
            app.StartupNextInstance += startupHandler;
            app.Run(new string[0]);
        }        
    }
