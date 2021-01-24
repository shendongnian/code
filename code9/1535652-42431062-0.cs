        private void Gr_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            DataGridTextColumn col = e.Column as DataGridTextColumn;
            if (col != null)
            {
                Binding binding = new Binding("[" + col.Header.ToString() + "]");
                binding.Mode = BindingMode.TwoWay;
                binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged; 
                col.Binding = binding; 
            }
        }
