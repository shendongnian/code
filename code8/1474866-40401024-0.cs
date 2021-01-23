    if (dataGridView1.SelectedRows[0].DefaultCellStyle.BackColor == Color.Red)
                {
                    int row = (int)this.dataGridView1.CurrentCell.OwningRow.Cells["id"].Value; 
                   // selected cells owning rows ID cell's value will give the ID
                    if (MessageBox.Show("Check-out?",
                                      "Message de confirmation",
                                      MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        using (checkinentrepriseEntities2 context = new checkinentrepriseEntities2())
                        {
                            badge badg = new badge();
                            badge badverif = context.badge.FirstOrDefault(x => x.id == row);
                            if (badverif != null)
                            {
                                badverif.bool_badge = 0;
                                context.SaveChanges(); // and savechanges after set update value
                            }
                        }
                    }
                }
