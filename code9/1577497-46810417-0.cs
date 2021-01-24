    public static void AutoColumnsFromProperties<T>(GridColumnFactory<T> columns, bool multiFilterable = true) where T: class
     {
    		//Hidden:
    		//
    		//<ScaffoldColumn(False)>
    		//Public Property RowNum As Integer
    
    		//Order and width:
    		//
    		//<Display(Order:=0, Name:="Mat Nr")>
    		//<GridColumn(Width:=80)>
    		//Public Property Material_Nr As String
    
    		foreach (var propertyInfo in ObjectPropertyHelper.GetVisibleProperties(typeof(T), true).OrderBy((x) => Annotations.GetOrderNumber(x, 0)))
    		{
    
    			var width = Annotations.GetGridColumnWidth(propertyInfo, null);
    			columns.Bound(propertyInfo.Name).Width(width).Filterable((ftb) => ftb.Multi(multiFilterable));
    
    		}
    	}
