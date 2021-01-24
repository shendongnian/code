    public void IsProfessional()
    {
        if (CurrentUser.IsAdmin!= true)
        {
                lblNo.Visibility= Visibility.Visible;
        }
        else
        {
                lblNo.Visibility = Visibility.Hidden;
        }
    }
