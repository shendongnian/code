    class Program
    {
        //Normal entry point
        static public void Main()
        {
            Main(new MainForm());
        }
  
        //Internal & test entry point
        static public void Main(Form form)
        {
            DoSomeSetup();
            Application.Run(form);
        }
    }
