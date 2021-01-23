        private void Form1_Load(object sender, EventArgs e)
        {
            for (var i = 0; i < 4; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    var button = new Button { Top = 50 * i, Left = 100 * j , Text = $@"Button {i * 4 + j + 1}", Tag = $@"{i},{j}"};
                    button.Click += ButtonOnClick;
                    Controls.Add(button);
                }
            }
        }
        private static void ButtonOnClick(object sender, EventArgs eventArgs)
        {
            var button = (Button) sender;
            MessageBox.Show(button.Tag.ToString());
        }
