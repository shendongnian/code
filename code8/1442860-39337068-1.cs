    private void button1_Click(object sender, EventArgs e)
    {
       var mapping = new Dictionary<RadioButton, Func<MyClass, bool>>()
       {
          { radioButtonName , x => x.Name == radioButtonName.Text },
          { radioButtonAge, x => x.Age == radioButtonAge.Text },
          { radioButtonGender, x => x.Gender == radioButtonGender.Text},
          { radioButtonOccupation, x => x.Occu == radioButtonOccupation.Text}
       };
    
       foreach(var map in mapping.Where(x=> x.Key.Checked))
       {
           var Qr = mylist.Where(map.Value).Select(n=> new {n.Name, n.Age, n.Occu, n.Gender});
           foreach (var item in Qr)
           {
              listBox1.Items.Add("Name: " + item.Name + "   " + "  Age: " + item.Age + "   " 
                               + "  Occupation: " + item.Occu + "   " + "  Gender: " 
                               + item.Gender);
           }
       }
       
    }
