            btn.Click += async delegate
            {
                for(int i=0; i<5; i++)
                {
                    text1.Text = i.ToString();
                    await Task.Delay(1000);
                }
            };
