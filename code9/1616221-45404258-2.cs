    string[] lines;
    int index;
    private void menu_open_Click(object sender, RoutedEventArgs e)
    {
        OpenFileDialog ofd = new OpenFileDialog();
        if (ofd.ShowDialog() == true)
        {
            lines = File.ReadAllLines(ofd.FileName);
            index = 0;
            Display(index);            
        }
    }
    private void Display(int number)
    {
        int i = number * 7; // 7 is a number of values per item
        tbox_name.Text = lines[i];
        tbox_dob.Text = lines[i+1];
        tbox_number.Text = lines[i+2];
        tbox_nationality.Text = lines[i+3];
        tbox_height.Text = lines[i+4];
        tbox_weight.Text = lines[i+5];
        tbox_position.Text = lines[i+6];    
    }
