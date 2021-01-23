            private void numericUpDown1_ValueChanged(object sender, EventArgs e)
            {
                var o = (NumericUpDown) sender;
                int thisValue = (int) o.Value;
                int lastValue = (o.Tag == null) ? 0 : (int)o.Tag;
                o.Tag = thisValue;
    
                if (checkBox1.Checked) //some custom logic probably
                {
                    //remove this event handler so it's not fired when you change the value in the code.
                    o.ValueChanged -= numericUpDown1_ValueChanged;
                    o.Value = lastValue;
                    o.Tag = lastValue;
                    //now add it back
                    o.ValueChanged += numericUpDown1_ValueChanged;
                }
                //otherwise allow as normal
            }
