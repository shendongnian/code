	public static int Pbase = 0x00509B74;
	public static int Health = 0xf8;
	public static int mgammo = 0x150;
	public static int fly = 0x44;
	/// <summary>The main entry point for the application.</summary>
	static void Main(string[] args)
	{
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(false);
		var f = new Form1();
		f.Show();
        VAMemory vam = new VAMemory("ac_client");
        int localplayer = vam.ReadInt32((IntPtr)Pbase);
		while (f.Visible)
		{
			int address = localplayer + fly;
			float aimlock = vam.ReadFloat((IntPtr)address);
			vam.WriteFloat((IntPtr)address, -5);
			address = localplayer + Health;
			vam.WriteInt32((IntPtr)address, 1337);
			address = localplayer + mgammo;
			vam.WriteInt32((IntPtr)address, +1337);
			Application.DoEvents();  //Yield control to the message loop
		}
	}
