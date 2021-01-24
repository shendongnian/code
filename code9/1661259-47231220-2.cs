    using System.Reflection;
    namespace TestWinform
    {
        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main(string[] args)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
    
                if (args.Length > 0)
                {
                    var _formName = (from t in System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                        where t.Name.Equals(args[0])
                        select t.FullName).Single();
                    var _form = (Form) Activator.CreateInstance(Type.GetType(_formName));
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
