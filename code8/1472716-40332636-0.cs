    private string OldValue
    {
        get
        {
            var viewStateVal = ViewState["OldValue"] as string;
            if (viewStateVal == null)
                return string.Empty;
            return viewStateVal;
        }
        set
        {
            ViewState["OldValue"] = value;
        }
    }
    protected void tbDesc_TextChanged(object sender, EventArgs e)
    {
      string newvalue = tbDesc.Text;
      if (newvalue != OldValue)
      {
          tbDesc.BackColor = Color.Yellow;
          OldValue = newvalue;
      }
      else
          tbDesc.BackColor = Color.White;
    }
