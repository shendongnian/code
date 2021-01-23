    for (int i = 0; i < metroGrid1.Rows.Count; i++)
      {
         if (metroGrid1.Rows[i].Cells[0].Value.ToString() == radGridView1.SelectedRows[0].Cells[0].Value.ToString())
        {                            
          counter = i;
          metroGrid1.Rows[counter].Cells[2].Value = Convert.ToInt32(metroGrid1.Rows[counter].Cells[2].Value) + radSpinEditor1.Value;
          MessageBox.Show("for loop");                          
         }    
         else
         {
                        metroGrid1.Rows.Add(radGridView1.SelectedRows[0].Cells[0].Value.ToString(), radGridView1.SelectedRows[0].Cells[1].Value.ToString() + " " + radGridView1.SelectedRows[0].Cells[2].Value.ToString() + " " + radGridView1.SelectedRows[0].Cells[3].Value.ToString() + " " + radGridView1.SelectedRows[0].Cells[4].Value.ToString(), radSpinEditor1.Value, decimal.Round(prodamt, 2), decimal.Round(prodtotamt, 2));
                        totamt += prodtotamt;
                        metroLabelTotalamt.Text = (string.Format("{0:#,###0.00}", totamt));
                        radSpinEditor1.Value = 1;
                        MessageBox.Show("else ");
     
         }                                         
 }
