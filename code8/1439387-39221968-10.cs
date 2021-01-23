    private void Form1_Load(object sender, EventArgs e)
    {
        txt1.Tag = txt2;
        txt3.Tag = txt4;
        txt1.MouseDown += new MouseEventHandler(txt_MouseDown);
        txt1.MouseMove += new MouseEventHandler(txt_MouseMove);
        txt1.MouseUp += new MouseEventHandler(txt_MouseUp);
        txt3.MouseDown += new MouseEventHandler(txt_MouseDown);
        txt3.MouseMove += new MouseEventHandler(txt_MouseMove);
        txt3.MouseUp += new MouseEventHandler(txt_MouseUp);
        
        .. 
      }
