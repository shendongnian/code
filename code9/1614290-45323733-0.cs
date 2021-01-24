        DataContextChanged += (object sender, DependencyPropertyChangedEventArgs e) =>
        {
            var oldVM = e.OldValue as VMClass;
            var newVM = e.NewValue as VMClass;
            if (oldVM != null)
            {
                oldVM.Check -= CheckingCode;
            }
            if (newVM != null)
            {
                newVM.Check += CheckingCode;
            }
        } 
