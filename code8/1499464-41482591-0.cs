    dateFactory.SetBinding(
                        //My IsEnabled property I wanted to change
                        IsEnabledProperty,
                        new Binding("IsLockedDatagrid")
                        {
                            //Datagridwidget is the datagrid I am using where I can found the IsLockedDatagrid boolean variable (in my xaml)
                            RelativeSource =
                                new RelativeSource(RelativeSourceMode.FindAncestor, typeof(DataGridWidget), 1),
                            Mode = BindingMode.OneWay,
                            UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                        });
