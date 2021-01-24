    private void RandomLabel_MouseEnter(object sender, EventArgs e)
    {
        Control control = sender as Control;
        if (sender != null)
        {
            control.Font = new Font(control.Font, FontStyle.Bold);
        }
        else
        {
            throw new InvalidArgumentException("sender");
        }
    }
