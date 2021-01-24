    public partial class Form2 : Form
    {
    	public Form2()
    	{
    		InitializeComponent();
    	}
    
    	public void UpdateLabel(string Message)
    	{
    		if (B01CountDown.InvokeRequired)
    		{
    			B01CountDown.Invoke((MethodInvoker)(() =>
    			{
    				B01CountDown.Text = Message;
    			}));
    		}
    	}
    }
