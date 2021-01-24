        Console.WriteLine("Press return to launch the form.");
        Console.ReadLine();
    
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
    
        ClassLibraryWithForm.TestForm testForm = new ClassLibraryWithForm.TestForm();
    
        System.Threading.Thread worker = new System.Threading.Thread(DoWork);
        worker.Start(testForm);
    
        Application.Run(testForm);
    }
    
    private static void DoWork(object formObject)
    {
        ClassLibraryWithForm.TestForm form = formObject as ClassLibraryWithForm.TestForm;
    
        for (int i=0; i<=30; ++i)
        {
            form.UpdateTextBox(i.ToString());
            System.Threading.Thread.Sleep(1000);
        }
    }
