    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Program
    {
    	private static Form f1 = new Form();
    	public static void Main()
    	{
    		f1.button1.Text = "Button 1";
    		f1.button2.Text = "Button 2";
    		// The Click method will change the buttons but the change 
    		// will only be within the Click method. Not outside.
    		f1.button1.Click(f1.button1, EventArgs.Empty);
    		
    		// This will still write "Button 1"
    		Console.WriteLine(f1.button1.Text);
    		
    		// Now if we do the assignment like this
    		f1.button1 = f1.button2;
    		f1.button1.Click(f1.button1, EventArgs.Empty);
    		
    		// this will write "Button 2"
    		Console.WriteLine(f1.button1.Text);
    		
    		// Now pass as reference
    		// We will pass button3 whose text is "Button 3" but it will be assigned
    		// to button4, so the output will be "Button 4"
    		f1.button3.Text = "Button 3";
    		f1.button4.Text = "Button 4";
    		button1_Click(ref f1.button3, EventArgs.Empty);
    		Console.WriteLine(f1.button3.Text);
    	}
    
    	public static void button1_Click(ref Button sender, EventArgs e)
    	{
    		sender = f1.button4;
    	}
    }
    
    public class Form
    {
    	public Button button1 = new Button();
    	public Button button2 = new Button();
    	public Button button3 = new Button();
    	public Button button4 = new Button();
    	public Form()
    	{
    		button1.Click += button1_Click;
    		button2.Click += button1_Click;
    	}
    
    	public void button1_Click(object sender, EventArgs e)
    	{
    		var clickedButton = (Button)sender;
    		clickedButton = this.button2;
    	}
    }
    
    public class Button
    {
    	public EventHandler Click;
    	public string Text
    	{
    		get;
    		set;
    	}
    }
 
