            try
            {   
              int n = gridPrchaseOrder.Rows.Add();
              gridPrchaseOrder.Rows[n].Cells[0].Value = customDropDown.grdItmName;
                gridPrchaseOrder.Rows[n].Cells[1].Value = customDropDown.grdItmDisrption;
                gridPrchaseOrder.Rows[n].Cells[2].Value = customDropDown.grdItmCata;
                gridPrchaseOrder.Rows[n].Cells[3].Value = customDropDown.grdItmPrice;
                customDropDown.Focus();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
