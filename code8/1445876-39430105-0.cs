            public string valueToForm1 { get; set; } //public properties to access from form1
            public DateTime value2ToForm1 { get; set; }
            private void button1_Click(object sender, EventArgs e)
            {
                this.valueToForm1 = "SomeValue";
                this.value2ToForm1 = dateTimePicker1.Value;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
