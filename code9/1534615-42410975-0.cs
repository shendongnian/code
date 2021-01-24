    private void OnTakeOneClick(object sender, RoutedEventArgs e)
    {
        var tableSelectedItem = (PartialPaymentDTO)this.TableDataGrid.SelectedItem;
        Model.TakeOrderItemsFromTable(tableSelectedItem);
    
        if(tableSelectedItem.QuantityOnTable != 0)
        {
            this.TableDataGrid.SelectedItem = tableSelectedItem;
        }
        else
    	{
    		int currentSelectedItemIndex = this.TableDataGrid.Items.IndexOf(tableSelectedItem);
    		// Skip items before currently selected items
    		var tableDataGridItemsAfterSelected = this.TableDataGrid.Items.OfType<PartialPaymentDTO>().Skip(currentSelectedItemIndex);
    		foreach (var item in tableDataGridItemsAfterSelected)
    		{
    			if (item.QuantityOnTable != 0) // Criteria check
    			{
    				this.TableDataGrid.SelectedItem = item;
    				break;
    			}
    		}
    	}
    }
