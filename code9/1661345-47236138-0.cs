    private void EquipDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                try
                {
                    var row_list = GetDataGridRows(EquipDataGrid);
                    foreach (DataGridRow single_row in row_list)
                    {
                        if (single_row.IsSelected == true)
                        {
                            EquipmentView selectedEquipment = (EquipmentView)EquipDataGrid.SelectedItem;
                            using (wiki_nolek_dk_dbEntities db = new wiki_nolek_dk_dbEntities())
                            {
                                db.Configuration.LazyLoadingEnabled = true;
                                var equipmentRelation = db.EquipmentComponents.Where(c => c.EquipmentID == selectedEquipment.EquipmentId);
                                var componentsForEquipment = new List<Component>();
                                foreach (var row in equipmentRelation)
                                {
                                    var component = db.Components.FirstOrDefault(c => c.ComponentId == row.ComponentID);
                                    componentsForEquipment.Add(component);
                                }
                                CompDataGrid.ItemsSource = componentsForEquipment;
                            }
                        }
                    }
    
                }
                catch
                {
                    MessageBox.Show("Det valgte udstyr eksisterer ikke.");
                }
            }
