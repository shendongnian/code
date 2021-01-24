     private void disableButtons()
        {
            for (int x = 0; x < Controls.GetLength(); x++)
                if (Controls[x].GetType() == typeof(Button))
                    Controls[x].Enabled = false;
        }
