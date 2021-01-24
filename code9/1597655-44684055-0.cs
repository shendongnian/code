    public UserControl myControl(){ /* copy your current view code here */}
    
    public Form myForm(){
      Controls.Add(new myControl());
    }
    
    public Form myTabbedForm(){
      var tabControl = new TabControl();
      var page1 = new TabPage();
      page1.Controls.Add(new myControl());
      tabControl.TabPages.Add(page1);
      this.Controls.Add(tabControl);
    }
