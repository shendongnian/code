    private Order GetOrderFromTextBoxes() {
      int orderNum = 0;
      int.TryParse(tbOrderNr.Text, out orderNum);
      string cust = tbCustommer.Text;
      string mat = tbMaterial.Text;
      string code = tbForm2MatCode.Text;
      return new Order(orderNum, cust, mat, code);
    }
    
    private void GetOrderItemsFromDGV(Order inOrder) {
      double doubleValue = 0;
      double length = 0;
      double width = 0;
      double qty = 0;
      string texture = "";
      foreach (DataGridViewRow r in dataGridView1.Rows) {
        if (!r.IsNewRow) {
          if (r.Cells[0] != null)
            double.TryParse(r.Cells[0].Value.ToString(), out doubleValue);
          length = doubleValue;
          if (r.Cells[1] != null)
            double.TryParse(r.Cells[1].Value.ToString(), out doubleValue);
          width = doubleValue;
          if (r.Cells[2] != null)
            double.TryParse(r.Cells[2].Value.ToString(), out doubleValue);
          qty = doubleValue;
          if (r.Cells[3] != null)
            texture = r.Cells[3].Value.ToString();
          inOrder.OrderInfo.Add(new OrderItem(length, width, qty, texture));
        }
      }
    }
