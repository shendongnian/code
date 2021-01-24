    private Control _control;
    private int _tabIndex;
    public Form1()
    {
        InitializeComponent();
        KeyDown += FormEvent; // subscribe to event
    }
    private void FormEvent(object sender, KeyEventArgs e)
    {
        // if pressed key is not tab, or there is no active form return
        if (e.KeyCode != Keys.Tab || ActiveForm == null) return;
        // get the control which currently has focus and get its tab index
        _control = ActiveForm.ActiveControl;
        _tabIndex = _control.TabIndex;
        // iterate through all the controls on the form
        for (var i = 0; i < Controls.Count; i++)
        {
            // continue until the next control which has to gain focus is found
            if (Controls[i].TabIndex != _tabIndex + 1) continue;
            // control found but its not suppose to gain focus on tab,
            if (!Controls[i].TabStop)
            {
                i = -1; // start from the beggining of the loop
                _tabIndex++; // search for the next control
            }
            // control found, focus on it
            else
                ActiveForm.ActiveControl = Controls[i];
        }
    }
