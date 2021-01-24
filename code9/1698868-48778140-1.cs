    static void Main(string[] args)
    {
            Console.WriteLine("Press return to launch the form.");
            Console.ReadLine();
        
            Application.EnableVisualStyles();
            
        
            MyForm testForm = new MyForm();
        
            System.Threading.Thread worker = new System.Threading.Thread(DoWork);
            worker.Start(testForm);
        
            Application.Run(testForm);
        }
        
        private static void DoWork(object formObject)
        {
            MyForm form = formObject as MyForm;
        
            for (int i=0; i<=30; ++i)
            {
                form.UpdateLabel(i.ToString());
                System.Threading.Thread.Sleep(1000);
            }
        }
