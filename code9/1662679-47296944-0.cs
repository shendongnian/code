    private void panels_Click(object sender, EventArgs e)
    {
        List<string> panelNames = new List<string>
        {"panel1", "panel2", "panel3", "panel4", "panel5", "panel6"};
        List<string> buttonNames = new List<string>
        {"button1", "button2", "button3", "button4", "button5", "button6"};
        List<Control> panels = this.Controls.Cast<Control>()
            .Where(ctrl => panelNames.Contains(ctrl.Name)).ToList();
        List<Control> buttons = this.Controls.Cast<Control>()
            .Where(ctrl => buttonNames.Contains(ctrl.Name)).ToList();
        Button thisButton = sender as Button;
        for (int i = 0; i < buttons.Count; i++)
        {
            if (i < panels.Count) panels[i].Visible = buttons[i] == thisButton;
        }
    }
