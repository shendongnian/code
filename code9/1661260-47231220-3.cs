    using System.Reflection;    // add this ;)
    namespace TestWinform
    {
        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main(string[] args)    // change this ;)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
    
                if (args.Length > 0)       // check here ;)
                {
                    var _formName = (from t in System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                        where t.Name.Equals(args[0])
                        select t.FullName).Single();
                    var _form = (Form) Activator.CreateInstance(Type.GetType(_formName));     // get result and cast to Form object in order to run below
                    if (_form != null)
                        _form.Show();
                }
                else
                {
                    //no argument passed, no form to open ;)
                }
    
                
            }
        }
    }
