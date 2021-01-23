        private static void OnTemplateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var This = d as MasterTreeUserControl;
            var template = e.NewValue as HierarchicalDataTemplate;
            if(template != null)
            {
                This.ItemListView.Resources[new DataTemplateKey(template.DataType)] = template;
            }
        }
