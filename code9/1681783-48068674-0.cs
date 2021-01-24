    Picturebox1.Image=....
    for(int i=0;i<10;i++)
    {
        uscontrol a=new uscontrol()
        {
            usimage=Image.Fromfile....  
        };
        a.MouseClick += new MouseEventHandler(USControl_Clicked); //Note this added line 
        panel1.Controls.Add(a);
    }
