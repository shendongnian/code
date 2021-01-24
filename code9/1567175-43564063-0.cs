    static class Program
    {
        //This is where we set the current form running -- or to be run.
        static Form CurrentForm;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Obviously, Form 1 starts everything so we hardcode that here on startup.
            CurrentForm = new Form1();
            //Then call our Run method we created, which starts the cycle.
            Run();
        }
        //This runs the current form
        static void Run()
        {
            //Tell our program to run this current form on the application thread
            Application.Run(CurrentForm);
            //Once the form OFFICIALLY closes it will execute the code below
            //Until that point, imagine Application.Run being stuck there
            if(CurrentForm != null && CurrentForm.IsDisposed == false)
            {
                //If our current form is NOT null and it is NOT disposed,
                //Then that means the application has a new form to display
                //So we will recall this method.
                Run();
            }
        }
        //This method is what we will call inside our forms when we want to
        //close the window and open a new one.
        public static void StartNew(Form form)
        {
            //Close the current form running
            CurrentForm.Close();
            //Set the new form to be run
            CurrentForm = form;
            
            //Once all this is called, imagine the program now 
            //Releasing Application.Run and executing the code after
        }
    }
