    private void InitializeForm()
    {
        var layoutPanel = new FlowLayoutPanel();
        // todo: initialize flow layout panel here...
        layoutPanel.Controls.Add(CreatePanel("Name"));
        layoutPanel.Controls.Add(CreatePanel("Email"));
        // etc
        this.Controls.Add(layoutPanel);
    }
    private Panel CreatePanel(string labelText)
    {
        var label = new Label(labelText);
        // todo: initialize label here...
        var textBox = new TextBox();
        // todo: initialize textbox here...
        var panel = new Panel();
        panel.Controls.Add(label);
        panel.Controls.Add(textBox);
        // todo: initialize panel here...
        return panel;
    }
