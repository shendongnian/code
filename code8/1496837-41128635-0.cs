    public class FormClass
    {
    	Process runningProcess;
    	
    	public FormClass()
    	{
    		InitializeComponent();
    	}
    	
    	private void button1_Click(object sender, EventArgs e)
    	{
    		var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "folder\\python.exe");   
    		runningProcess = Process.Start(filePath); 
    	}
    	
    	private void button2_Click(object sender, EventArgs e)
    	{
    		if(!runningProcess.HasExited)
    		{
    			runningProcess.Kill();
    		}
    	}
    }
