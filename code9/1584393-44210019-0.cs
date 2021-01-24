        private void ImportarView_ColumnsToMapChanged(object sender, ColumnsToMapChangedEventArgs e)
        {
            ImportColumns = e.Columns;
            Importar source = ((Importar)GrdMain.DataContext);
            DGrdDatosImportar.Columns.Clear();
            foreach (ColumnParms columnparms in ImportColumns)
            {
                #region Crear la columna
                ImportColumn Col = new ImportColumn()
                {
                    Header = columnparms,
                    Binding = new Binding($"{columnparms.ColumnName}.DisplayValue"),
                    Visibility = Visibility.Visible,
                    ColParms = columnparms
                };
                #endregion
                #region Text block Nombre de la columna
                Binding txtBind = new Binding("TextProperty") { Path = new PropertyPath("DisplayString", null) };
                var MyTb = new FrameworkElementFactory(typeof(TextBlock));
                MyTb.SetBinding(TextBlock.TextProperty, txtBind);
                #endregion
                Col.HeaderTemplate = new DataTemplate() { VisualTree = MyTb };
                DGrdDatosImportar.Columns.Add(Col);
            }
        }
