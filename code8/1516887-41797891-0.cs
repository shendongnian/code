    private double[] grades = new double[10]; // 10 grades
    private string[] names = new string[10]; // 10 names
    private int currentIndex = 0;
    private void Grade_Click(object sender, EventArgs e)
    {
        if (currentIndex > 10)
        {
            MessageBox.Show("No more enteries allowed");
        }
    
        string name;
        double grade;
    
        if (double.TryParse(gradetextbox.Text, out grade))
        {
            grades[currentIndex] += grade;
        }
        else
        {
            MessageBox.Show("Grade enterd is not a valid grade");
            return;// do nothing else
        }
    
        name = nametextbox.Text;
        names[i] += name;
    
        // now clear the textboxes so user can enter another value
        nametextbox.Text = "";
        gradetextbox.Text = "";
        currentIndex = currentIndex + 1;
    }
