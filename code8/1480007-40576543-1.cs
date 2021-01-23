    public class CategoryDialog : Form
    {
    	public CategoryDialog()
    	{
    		button1 = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            Controls.Add(button1);
    	}
     
    	Button button1;
        
        // this property will let you access button
    	public Button Button1 { get { return button1; } }
    }
