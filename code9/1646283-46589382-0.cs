        private void GenerateControls(string formType)
        {
            string[] formParameters = engine.GetFormParameters(formType);
            if (formParameters == null) return;
            SplitterPanel panel = splitContainer.Panel1;
            panel.Controls.Clear();
            int tabIndex = 0;
            Point labelPoint = panel.Location + new Size(20, 20);
            Size verticalOffset = new Size(0, 30);
            Size horizontalOffset = new Size(100, 0);
            Size tBoxSize = new Size(40,20);
            foreach (string parameter in formParameters)
            {
                Label label = new Label
                {
                    Text = parameter,
                    Tag = "Parameter Label",
                    Name = $"lbl{parameter}",
                    Location = (labelPoint += verticalOffset)
                };
                panel.Controls.Add(label);
                TextBox textBox = new TextBox
                {
                    AcceptsTab = true,
                    TabIndex = tabIndex++,
                    Text = "",
                    Tag = parameter,
                    Name = $"txt{parameter}",
                    MaximumSize = tBoxSize,
                    MinimumSize = tBoxSize,
                    Size = tBoxSize,
                    Location = labelPoint + horizontalOffset
                };
                panel.Controls.Add(textBox);
            }
        }
