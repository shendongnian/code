    private void dgProducts_ColumnHeaderMouseClick(object sender, 
    DataGridViewCellMouseEventArgs e)
    {
     var compareList = (dgProducts.DataSource as List<StockM>);
     string strColumnName = dgProducts.Columns[e.ColumnIndex].Name;
     SortOrder strSortOrder = getSortOrder(e.ColumnIndex);
     if (strSortOrder == SortOrder.Ascending)
     {
         _allstock = _allstock.OrderBy(x => typeof(StockM).GetProperty(strColumnName).GetValue(x, null)).ToList();
      }
       else
      {
         compareList = compareList.OrderByDescending(x => typeof(StockM).GetProperty(strColumnName).GetValue(x, null)).ToList();
      }
    dgProducts.DataSource = compareList;
    dgProducts.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = strSortOrder;
    }
