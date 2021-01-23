		static void Main(string[] args)
		{
			Initialise();
			if (!RunSilently)
				FireUpGui();
			else
				RunConsoleApp();   // not so relevant to the answer
		}
		private static void FireUpGui()
		{
			Console.SetWindowSize(80, 5);
			Thread t = new Thread(Start_Wpf);
			t.SetApartmentState(ApartmentState.STA);
			t.Start();
		}
		static App WpfApp;
		static void Start_Wpf()
		{
			WpfApp = new App();   // my WPF App
			WpfApp.Run();
		}
	
