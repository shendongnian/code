    public Form()
    {
      this.InitializeComponent();
      //Attach to the event
      StyleManager.Instance.StyleChanged += this.StyleChanged;
    }
 
    //Handle event
    private void StyleChanged(object sender, EventArgs eventArgs)
    {
      this.BackColor = StyleManager.Instance.BackColor;
    }
    //set backcolor of all forms
    StyleManager.Instance.UpdateBackColor(Color.Yellow);
