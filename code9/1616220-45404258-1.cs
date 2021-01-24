    private void menu_save_Click(object sender, RoutedEventArgs e)
    {
        SaveFileDialog sfd = new SaveFileDialog();
        if (sfd.ShowDialog() == true)
        {
            File.AppendAllLines(sfd.FileName, new string []
            {
                tbox_name.Text,
                tbox_dob.Text,
                tbox_number.Text,
                tbox_nationality.Text,
                tbox_height.Text,
                tbox_weight.Text,
                tbox_position.Text,
            });
        }
    }
