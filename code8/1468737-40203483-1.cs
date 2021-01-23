    List<Dog> dogs = new List<Dog>();
    private void createBtn_Click(object sender, EventArgs e)
            {
                Dog myDog = new Dog(textBox1.Text, textBox2.Text, int.Parse(textBox3.Text), textBox4.Text);
                dogs.Add(myDog);
            }
