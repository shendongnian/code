        public class MainForm(): Form
        {
          // ..
           IMySomeThing _mySomething;
        
           public MainForm()
           {
            _mySomeThing =   (IMySomeThing)Program.ServiceProvider.GetService(typeof(iMySomething));
           }     
        }
