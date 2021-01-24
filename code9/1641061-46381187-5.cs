    public void checktablenoandchangebtncolor()   
    {
      var btns = this.GetAllControls()
        .OfType<Button>()
        .ToLookup(x=>x.Text, x=>x);
      /* Turn all buttons grey */
      foreach(var grp in btns)
      {
        foreach(btn in grp)
        {
          btn.BackColor = Color.Grey;
        }
      }
      using(var con = new SqlConnection(...))
      {
        var query = "SELECT tableno FROM kottemp";
        foreach(var key in con.GetList<string>(query));
        {
          foreach(var btn in btns[key])
          {
            btn.BackColor = Color.Red;
          }
        }
      }
    }
