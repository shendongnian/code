     private void disableButtons()
        {
            for (int x = 0; x < Controls.GetLength(); x++)
                if (Controls[x] is Button)
                    Controls[x].Enabled = false;
        }
