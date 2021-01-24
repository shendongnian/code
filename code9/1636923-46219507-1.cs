    private void btnNext_Click(object sender, RoutedEventArgs e)
    {
        student.i++;
        if (...)
        { ... }
        else 
        {
            MessageBox.Show("list is full");
            student.i--; // undo change
        }
    }
    
    private void btnPrevious_Click(object sender, RoutedEventArgs e)
    {
        student.i--;
        if (...)
        { ... }
        else
        {          
            MessageBox.Show("no data");
            student.i++; // undo change
        }
    }
