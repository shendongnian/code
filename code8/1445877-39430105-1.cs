       private void button1_Click(object sender, EventArgs e)
            {
                using (var form = new Form2())
                {
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        //values preserved after close
                        string val = form.valueToForm1;            
                        DateTime dateValue = form.value2ToForm1;
                        //for example
                        this.txtValueFromForm2.Text = val;
                        this.dateTimePicker1.Value = dateValue;
                    }
                }
            }
