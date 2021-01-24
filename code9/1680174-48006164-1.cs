    void button1_KeyDown(object sender, KeyEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.Down:
            case Keys.Up:
                if (button1.ContextMenuStrip != null)
                {
                    button1.ContextMenuStrip.Show(button1,
                        new Point(0, button1.Height), ToolStripDropDownDirection.BelowRight);
                }
                break;
        }
    }
