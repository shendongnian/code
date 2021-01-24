        public class MainForm: Form
        {
          // ..
           private readonly IMySomeThing _mySomething;
        
           public MainForm()
           {
            _mySomething =   (IMySomeThing)Program.ServiceProvider.GetService(typeof(iMySomething));
           }     
        }
