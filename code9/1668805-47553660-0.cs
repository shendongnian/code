    bool b1clicked = false, b2clicked = false;
    public void button2_Click(object sender, EventArgs e)
    {
       b2clicked = true;
    }
    
    public void button1_Click(object sender, EventArgs e)
    {
       b1clicked = true;
       if (b1clicked && b2clicked)
       {
          //...
       }
    }
