    //run this on the click of the button
    int button_id = 1; //or whatever way you want to reference your button
    //myButtons[button_id].Visible = false;
    var btnTimer = new System.Timers.Timer(2000);
    btnTimer.Elapsed += myTestClass.HideButton;
    btnTimer.Enabled = true;
    //keep a reference to that button so you know who the timer belongs to
    myTestClass.myTimers[btnTimer] = button_id;
    public static class myTestClass
    {
    	public static Dictionary<System.Timers.Timer, int> myTimers = new Dictionary<System.Timers.Timer, int>();
    	public static void HideButton(object sender, System.Timers.ElapsedEventArgs e)
    	{
    		System.Timers.Timer tmr = (System.Timers.Timer)sender;
    		if(myTimers.ContainsKey(tmr))
    		{
    			//here you get your reference back to the button to which this timer belongs, you can show/hide it
    			//var btn_id =  myButtons[myTimers[tmr]];
    			//myButtons[btn_id].Visible = false;
    			Console.WriteLine(myTimers[tmr]);
    		}
    		tmr.Enabled = false;
    	}
    }
