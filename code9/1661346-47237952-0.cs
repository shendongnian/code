            private void EquipDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                EquipmentView selectedEquipment = (EquipmentView)EquipDataGrid.SelectedItem;
                using (wiki_nolek_dk_dbEntities db = new wiki_nolek_dk_dbEntities())
                {
                    db.Configuration.LazyLoadingEnabled = true;
                    var equipmentRelationComponentIds =
                        db.EquipmentComponents
                            .Where(e => e.EquipmentID == selectedEquipment.EquipmentId)
                            .Select(e => e.ComponentId)
                            .ToList();
                    var componentsForEquipment =
                        db.Components
                            .Where(c => equipmentRelationComponentIds.Contains(c.ComponentId))
                            .ToList();
                    CompDataGrid.ItemsSource = componentsForEquipment;
                }
            }
            catch
            {
                MessageBox.Show("Det valgte udstyr eksisterer ikke.");
            }
        }
