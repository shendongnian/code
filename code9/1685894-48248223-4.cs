    private void btnGetUserInputTextBoxData_Click(object sender, EventArgs e)
    {
        var controls = Child.Controls;
        foreach (Character controlName in charList)
        {
            var ctr = (TextBox)controls.Find(controlName.Name, false).FirstOrDefault();
            Console.WriteLine(ctr.Text);
        }
    }
