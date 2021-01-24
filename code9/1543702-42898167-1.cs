    private void CellDataItem_ByColumn_ItemClick(object sender, ItemClickEventArgs e)
        {
            var menuInfo = view.GridMenu.MenuInfo as GridCellMenuInfo;
            if (menuInfo != null && menuInfo.Row != null)
            {
                var column = menuInfo.Column as GridColumn;               
                if (column == null) return;
                if ((String)column.ActualColumnChooserHeaderCaption == _nameColumn)//context menu under column "Name"
                {
                    //code here
                }
                else if(...)
				{}
               
            }
        }
