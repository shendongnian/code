    ...
    System.Windows.Forms.Timer t=new System.Windows.Forms.Timer();
    t.Interval=300000;
    t.Enabled=true;
    t.Tick+= new EventHandler(t_Tick);
    ...
    void t_Tick(object sender, EventArgs e)
    {
    Console.WriteLine("5 MIN");
    }
    ...
