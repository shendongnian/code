    static class Program
    {
        static Form CreateFormToOpen(string formName)
        {
            switch (formName)
            {
                case "ProductionDowntime":
                    return new ProductionDowntime();
                //  insert here as many case clauses as many different forms you need to open on startup
                default:
                    return new ProductionSystem();  //  ProductionSystem is a default form to open
            }
        }
        [STAThread]
        static void Main(string[] args)
        {
            string formName = args.Length > 0 ? args[0] : null;   //  extract form name from command line parameter
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(CreateFormToOpen(formName));    //  use factory method to instantiate form you need to open
        }
    }
}
