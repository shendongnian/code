      private void AA()
        {
            DataGridTemplateColumn templateColumn =
              (DataGridTemplateColumn)dataGrid.Resources["TemplateColumn"];
            dataGrid.Columns.Add(templateColumn);
            Random len = new Random();
            for (int i = 0; i <= 100; i++)
            {
                UV[i] = new UserControl1();
                UV[i].TextBoxMargin = new Thickness
                    (
                         len.Next(0, 50), len.Next(0, 0), len.Next(0, 50), len.Next(0, 0)
                    );
                UV[i].textBox.Margin = UV[i].TextBoxMargin;
    
                dataGrid.Items.Add(UV[i]);
            }
        }
