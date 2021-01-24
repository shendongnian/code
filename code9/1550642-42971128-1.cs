    private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (listView1 != null)
            {
                if (!listView1.Bounds.Contains(e.X, e.Y) && mTooltip != null)
                {
                    mTooltip.SetToolTip(listView1, "");
                    lastSubItem = null;
                }
            }
        }
