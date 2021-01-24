    [STAThread]
    static void Main()
    {
    	Application.EnableVisualStyles();
    	Application.SetCompatibleTextRenderingDefault(false);
    
    	Application.Run(new MyCustomApplicationContext());
    }
    public class MyCustomApplicationContext : ApplicationContext
    {
    	public static NotifyIcon trayIcon;
    
    	public MyCustomApplicationContext()
    	{
    		trayIcon = new NotifyIcon()
    		{
    			Icon = icon,
    			ContextMenu = new ContextMenu(new MenuItem[]
    			{
    				new MenuItem("Exit", Exit),
    				new MenuItem("Do something", DoSomething),
    			}),
    			Visible = true,
    			BalloonTipText = "My Application",
    			BalloonTipTitle = "My Application",
    			Text = "My Application Text"
    		};
    		trayIcon.Click += new System.EventHandler(trayIcon_Click);
    	}
    	
    	private void trayIcon_Click(object sender, System.EventArgs e)
    	{
    		//Do something
    	}
    	
    	void DoSomething(object sender, EventArgs e)
    	{
    	}
    	
    	void Exit(object sender, EventArgs e)
    	{
    		// Hide tray icon, otherwise it will remain shown until user mouses over it
    		trayIcon.Visible = false;
    
    		Application.Exit();
    	}
    }
