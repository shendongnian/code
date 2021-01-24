    private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool invalidStuffSelected = false;
            //throw new System.NotImplementedException();
            foreach (var obj in DataGrid.SelectedItems)
            {
                if (!(obj is PersonVM))
                    invalidStuffSelected = true;
            }
            MainVM vm = (MainVM) this.DataContext;
            if (invalidStuffSelected)
                vm.SelectedPerson = null;
        }
