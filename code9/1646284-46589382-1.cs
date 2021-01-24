        private void GenerateControls(string formType)
        {
            string[] formParameters = engine.GetFormParameters(formType);
            if (formParameters == null) return;
            SplitterPanel panel = splitContainer.Panel1;
            panel.Controls.Clear();
            int tabIndex = 0;
            Point labelPoint = panel.Location + new Size(20, 20);
            Size verticalOffset = new Size(0, 30);
            Size tBoxSize = new Size(200,20);
            int maxLabelLength = 0;
            foreach (string parameter in formParameters)
            {
                Label label = new Label
                {
                    Text = parameter,
                    Tag = "Parameter Label",
                    Name = $"lbl{parameter}",
                    Location = (labelPoint += verticalOffset),
                    AutoSize = true
                };
                panel.Controls.Add(label);
                if (label.Size.Width > maxLabelLength)
                {
                    maxLabelLength = label.Size.Width;
                }
            }
            Size horizontalOffset = new Size(maxLabelLength + 30, 0);
            labelPoint = panel.Location + new Size(20, 20) + horizontalOffset;
            foreach (string parameter in formParameters)
            { 
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
                    Location = labelPoint += verticalOffset
                };
                panel.Controls.Add(textBox);
            }
        }
