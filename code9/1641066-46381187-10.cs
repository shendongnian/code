    public void checktablenoandchangebtncolor()   
    {
      var btns = this.GetAllControls()
        .OfType<Button>();
      using(var con = new SqlConnection(...))
      {
        var query = "SELECT tableno FROM kottemp";
        var list = con.Query<string>(query);
        foreach(var btn in btns)
        {
          btn.BackColor = list.Contains(btn.Text)
            ? Color.Red
            : Color.Grey;
        }
      }
    }
