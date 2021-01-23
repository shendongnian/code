    private void nameBoxAdd_IsVisibleChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            if(!nameBoxAdd.IsVisible)
            {
                nameBoxAdd.UpdateLayout();
                Task.Delay(500); nameBoxAdd.Focus();
            }
        }
