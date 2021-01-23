    private String _sFirstName = "";
    private String _sLastName = "";
    
    public String FirstName { 
      get { return _sFirstName; }
      set { _sFirstName = value; UpdateLabel(); }
    }
    public String LastName { 
      get { return _sLastName; }
      set { _sLastName = value; UpdateLabel(); }
    }
    public String FullName {
      get { return _sFirstName + " " + _sLastName; }
    }
    private void UpdateLabel() {
      // do within a UI thread to prevent threading issues
      this.BeginInvoke((Action)(() => {
        labelFullName.Text = this.FullName.Trim();
      }));
    }
 
