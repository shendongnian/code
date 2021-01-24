    public partial class Form1 : Form
    {
        LowLevelKeyboardProcDelegate del;
        ...
		
		private void Form1_Load(object sender, EventArgs e) 
		{
			del = new LowLevelKeyboardProcDelegate(LowLevelKeyboardProc);
			intLLKey = SetWindowsHookEx(WH_KEYBOARD_LL, del, System.Runtime.InteropServices.Marshal.GetHINSTANCE(System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0]).ToInt32(), 0);            
		}
		...
	}
