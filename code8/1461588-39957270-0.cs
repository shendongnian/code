     this.Columns = new ObservableCollection<ColumnDescriptor>
            {
                new ColumnDescriptor { HeaderText = "IsChecked", DisplayMember = "IsChecked",Type="CheckBox" },
                new ColumnDescriptor { HeaderText = "FirstName", DisplayMember = "FirstName", Type="Common" },
                new ColumnDescriptor { HeaderText = "LastName", DisplayMember = "LastName", Type="Common" }
            };
