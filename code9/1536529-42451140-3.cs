    protected void Button1_Click(object sender, EventArgs e)
        {
          if (string.IsNullOrWhiteSpace(MyVar))
          {
            MyVar= "Return this on postback";
            varcheck(MyVar);
          }
    
        }
     
