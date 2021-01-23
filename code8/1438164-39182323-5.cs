    private void createButton(string name, string buttonText,string parentControlName)
        {
            Button b = new Button();
            b.Name = name;
            b.Text = buttonText;
            b.Click += myButton_Clicked;
            Control c = Controls.Find(parentControlName, true)[0];
            c.Controls.Add(b);
            
        }
