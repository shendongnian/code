    this.ButtonPlus.Tag = ExecutePlus;
    this.ButtonMinus.Tag = ExecuteMinus;
    // add "general" event handler
    var buttons = new[] { this.ButtonPlus, this.ButtonMinus };
    foreach(var button in buttons)
    {
        button.Click += Button_Click;
    }
