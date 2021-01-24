           MyItemVM myItem=this.tc.Items[0];
           TabItem tabItem = (TabItem)this.tc.ItemContainerGenerator.ContainerFromItem(myItem);
            
            Binding binding = new Binding();
            binding.Source = myItem;
            binding.Path = new PropertyPath("GroupBackground");
            binding.Mode = BindingMode.OneWay;
            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(tabItem, TabItem.BackgroundProperty, binding);
            myItem.GroupBackground = Brushes.LightCoral;
             
            MyItemVM myItem=this.tc.Items[1];
            tabItem = (TabItem)this.tc.ItemContainerGenerator.ContainerFromItem(myItem);
            binding = new Binding();
            binding.Source = myItem;
            binding.Path = new PropertyPath("GroupBackground");
            binding.Mode = BindingMode.OneWay;
            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(tabItem, TabItem.BackgroundProperty, binding);
           myItem.GroupBackground = Brushes.LightCoral;
