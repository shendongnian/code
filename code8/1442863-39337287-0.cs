    public void foo(RadioButton radioButton)
	 {
		 if (radioButton.Checked)
		{
						var Qr = from n in mylist where n.Occu == textBoxSearch.Text select new { n.Name, n.Age, n.Occu, n.Gender };
						foreach (var item in Qr)
						{
							listBox1.Items.Add("Name: " + item.Name + "   " + "  Age: " + item.Age + "   " + "  Occupation: " + item.Occu + "   " + "  Gender: " + item.Gender);
						}
		}
	 }
