    for (int i = 0; i < 10; i++)
            {
                foreach (Control item in Controls.OfType<Control>())
                {
                    if (item.Name == "dynamicButton")
                    {
                        Controls.Remove(item);                        
                    }
                }
            }
