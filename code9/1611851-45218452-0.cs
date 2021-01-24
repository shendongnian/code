    private void btnRightMenuHide_Click(object sender, RoutedEventArgs e)
    {
        switch (condition)
        {
            case "case 1":
                UserControl1 uc1 = new UserControl1();
                pnlRightMenu.Children.Add(uc1);
                break;
            case "case 2":
                UserControl2 uc2 = new UserControl2();
                pnlRightMenu.Children.Add(uc2);
                break;
            case "case 3":
                UserControl3 uc3 = new UserControl3();
                pnlRightMenu.Children.Add(uc3);
                break;
        }
    }
