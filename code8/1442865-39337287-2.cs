    public void foo(RadioButton radioButton, Expression<Func<MyItem, bool>> expression)
        {
            if (radioButton.Checked)
            {
                var Qr = mylist.AsQueryable().Where(expression).Select(x => String.Format("Name: {0}, Age: {1}, Occ: {2}, Gender: {3}", x.Name, x.Age, x.Occu, x.Gender)).ToList();
                
                foreach (var item in Qr)
                {
                    listBox1.Items.Add(item);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foo(radioButtonName, c => c.Gender == textBoxSearch.Text);
            foo(radioButtonAge, c => c.Age == textBoxSearch.Text);
            foo(radioButtonGender, c =>  c.Gender == textBoxSearch.Text);
            foo(radioButtonOccupation, c => c.Occu == textBoxSearch.Text);
        }
 
    public class MyItem
        {
            public String Occu { get; set; }
    
            public String Age { get; set; }
            public String Name { get; set; }
            public String Gender { get; set; }
    
        }
