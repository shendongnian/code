        cbo.LostFocus += (object sender, EventArgs e) => {
            foreach (Binding b in cbo.DataBindings)
            {
                if (string.Equals(b.PropertyName, "SelectedItem"))
                {
                    b.WriteValue();
                }                    
            }
        };
