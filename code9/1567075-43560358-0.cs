    private void btnUpdateIDQty_Click(object sender, EventArgs e) {
      Dictionary<string, int> IDCount = new Dictionary<string, int>();
      string curId = "";
      int curQty = 0;
      int oldValue;
      foreach (DataGridViewRow row in dgvPurchaseOrder.Rows) {
        if (row.Cells["JewelID"].Value != null && row.Cells["Quantity"].Value != null) {
          curId = row.Cells["JewelID"].Value.ToString();
          int.TryParse(row.Cells["Quantity"].Value.ToString(), out curQty);
          if (IDCount.ContainsKey(curId)) {
            IDCount.TryGetValue(curId, out oldValue);
            curQty += oldValue;
            IDCount[curId] = curQty;
          }
          else {
            IDCount.Add(curId, curQty);
          }
        }
        else {
          // one of the cells is null ignore
        }
      }
      StringBuilder sb = new StringBuilder();
      sb.Append("ID quantity totals" + Environment.NewLine);
      foreach (KeyValuePair<string, int> pair in IDCount) {
        sb.Append("JewelryID: " + pair.Key + " Total Qty: " + pair.Value + Environment.NewLine);
      }
      txtIDQuantity.Text = sb.ToString();
    }
