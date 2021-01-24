    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        string[] izbira1 = { "Kingston 2, 5'' SSD disk 480 GB, SATA3", "DELL monitor LED UltraSharp U2412M", "Lenovo IdeaPad 110" };
        string[] izbira2 = { "PCX namizni računalnik Exam i5-7400/8GB/SSD120+1TB/Win10H", "Lenovo prenosnik V310", "Intel procesor Core i7-5820K" };
        string[] izbira3 = { "HP prenosnik Pavilion 17-ab004nm", "Intel procesor Core i7 6900K", "Gigabyte grafična kartica GTX 1080 OC" };
        string[] izbira4 = { "Asus prenosnik FX502VM-DM311T", "HP prenosnik Omen 17-w103nm", "DELL prenosnik Alienware 17" };
        ComboBox cmb = (ComboBox)sender;
        int izbranIndex = cmb.SelectedIndex;
        switch (izbranIndex)
        {
            case 1:
                lvDataBinding.ItemsSource = izbira1;
                break;
            case 2:
                lvDataBinding.ItemsSource = izbira2;
                break;
            case 3:
                lvDataBinding.ItemsSource = izbira3;
                break;
            case 4:
                lvDataBinding.ItemsSource = izbira4;
                break;
        }
    }
