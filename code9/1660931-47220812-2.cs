    private void BTHookTB_Click(object sender, EventArgs e)
    {
        if (sender != null)
        {
            ControlHook TextBoxHook = new ControlHook
            {
                Text = LBListControl.SelectedItem.ToString(),
                Position = lRectangle[LBListControl.SelectedIndex],
            };
            lControlHook.Add(TextBoxHook);
            LabelTBHook.Text = "TextBox : " + lControlHook[1].Text;
            BTHookTB.Enabled = false;
            BTReset.Enabled = true;
            BTHook.Enabled = true;
            LBListControl.Enabled = false;
            ci.Hide();
        }
    }
