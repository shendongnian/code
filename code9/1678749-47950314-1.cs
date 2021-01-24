        for(int i = 0; i < Controls.OfType<Label>().Count; i++)
        {
            Label lbl = Controls.OfType<Label>()[i];
            if (lbl.Tag.ToString() == "Mass")
            {
                Controls.Remove(lbl);
                i--;
            }
        }
