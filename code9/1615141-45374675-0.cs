    for (int i = 0; i < 10; i++)
            {
                Button button = new Button();
                button.Left = left;
                button.Top = top;
                this.Controls.Add(button);
                top += button.Height + 2;
            }
