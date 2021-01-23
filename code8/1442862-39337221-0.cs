        private void button1_Click(object sender, EventArgs e)
        {
            // Generate anonymous list of objects that are different
            var radios = new[]
            {
                new { RadioButton = radioButtonName, CallBack = new Func<MyItem, bool>(x => x.Name == textBoxSearch.Text) },
                new { RadioButton = radioButtonAge, CallBack = new Func<MyItem, bool>(x => x.Age == textBoxSearch.Text) },
                new { RadioButton = radioButtonGender, CallBack = new Func<MyItem, bool>(x => x.Occu == textBoxSearch.Text) },
                new { RadioButton = radioButtonOccupation, CallBack = new Func<MyItem, bool>(x => x.Gender == textBoxSearch.Text) },
            };
            // Iterate through list and add items to ListBox1, if RadioButtton is checked
            listBox1.Items.Clear();
            foreach (var radio in radios)
            {
                if (!radio.RadioButton.Checked)
                {
                    continue;
                }
                var Qr = mylist.Where(radio.CallBack).Select(n => new { n.Name, n.Age, n.Occu, n.Gender });
                foreach (var item in Qr)
                {
                    listBox1.Items.Add($"Name: {item.Name}     Age: {item.Age}     Occupation: {item.Occu}     Gender: {item.Gender}");
                }
            }
        }
