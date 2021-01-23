    private void nameBoxAdd_IsVisibleChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            if(!nameBoxAdd.IsVisible)
            {
                nameBoxAdd.UpdateLayout();
                // Task.Delay(500); abundant
                nameBoxAdd.Focus(); 
                // After testing some more, the Task.Delay(500) is not needed either. 
                // It's just the combination of UpdateLayout() and Focus()
            }
        }
