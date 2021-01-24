    static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            if (args.Length > 0)       
            {
                OpenForm(args[0]);
            }
            
        }
    
            public static void OpenForm(string FormName)
            {
                var _formName = (from t in System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                    where t.Name.Equals(FormName)
                    select t.FullName).Single();
                var _form = (Form)Activator.CreateInstance(Type.GetType(_formName));
                if (_form != null)
                    _form.Show();
            }
