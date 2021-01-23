      if (gridView1.RowCount >= 1)
       {
                List<PurchaseChild> purchaseChild = new List<PurchaseChild>();
                PurchaseParent purchaseParent = new PurchaseParent()
                {
                    PurchaseDate = Convert.ToDateTime(txtPurchaseDate.EditValue),
                    PurchaseInvoice = txtInvoice.EditValue.ToString(),
                    CompanyInvoice = txtCompanyInvoice.EditValue.ToString(),
                    SupplyerId = cmbSupplyer.EditValue.ToString(),
                    DelivaryBy = txtDelivaryBy.EditValue.ToString(),
                    CreateBy = Settings.Default.UserName,
                    CreateDate = DateTime.Now,
                    PcName = txtComputerName.EditValue.ToString()
                };
                for (int i = 0; i < gridView1.DataRowCount; i++)
                {
                 purchaseChild.Add(new PurchaseChild()
                    {
                PurchaseInvoice = txtInvoice.EditValue.ToString(),
                ProductCode = gridView1.GetRowCellValue(i, "ProductCode").ToString(),
                Qty = Convert.ToInt16(gridView1.GetRowCellValue(i, "Qty")),
                ProductPrice = Convert.ToInt16(gridView1.GetRowCellValue(i, "ProductPrice")),
                SellingPrice = Convert.ToInt16(gridView1.GetRowCellValue(i, "SellingPrice")),
                DiscountPrice = Convert.ToInt16(gridView1.GetRowCellValue(i, "DiscountPrice") == null ? 0 : gridView1.GetRowCellValue(i, "DiscountPrice")),
                DiscountAmount = Convert.ToInt16(gridView1.GetRowCellValue(i, "DiscountPrice") == null ? 0 : gridView1.GetRowCellValue(i, "DiscountAmount")),
                TotalAmount = Convert.ToInt16(gridView1.GetRowCellValue(i, "Qty")) * Convert.ToInt16(gridView1.GetRowCellValue(i, "ProductPrice"))
                    });
                }
