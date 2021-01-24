    if ( listBox1.Items.Cast<string>().Contains( comboBox1.SelectedItem.ToString() ) )
    {
        MessageBox.Show( "duplicate" );
    }
    else
    {
        listBox1.Items.Add( comboBox1.SelectedItem );
    }
