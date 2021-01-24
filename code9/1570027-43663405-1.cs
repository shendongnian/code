    private void InitializeComponent()
    {
        // subscribe to the user control event
        this.myUserControl11.PropertyChanged += 
            new System.ComponentModel.PropertyChangedEventHandler(
                this.myUserControl11_PropertyChanged);
    }
    // handle the event by updating the other control
    private void myUserControl11_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        textBox1.Text = myUserControl11.ServerName;
    }
