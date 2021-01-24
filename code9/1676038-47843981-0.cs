    List testTable = context.Web.Lists.GetByTitle(tableName);
    
    var viewQuery = string.Format(@"<View>
    	<Query>
    	  <Where>
    		<And>		 
    		 <Leq>
    			<FieldRef Name='Start_Date' />
    			<Value Type='DateTime'><Today /></Value>
    		 </Leq>
    		 <Geq>
    			<FieldRef Name='End_Date' />
    			<Value Type='DateTime'><Today /></Value>
    		 </Geq>
    	  </And>
    	 </Where>
    	</Query>
    </View>");
    
    CamlQuery camlQuery = new CamlQuery
    {
    	ViewXml = viewQuery;
    };
    
    ListItemCollection GetSharePointList = testTable.GetItems(camlQuery);
    
    context.Load(GetSharePointList,
        items => items.Include(
        item => item.Id,
        item => item["DayOfMonth"],
    	item => item["Start_Date"],
    	item => item["End_Date"],
    	item => item["Task_FrequencyID_x003a_Frequency"],
    	item => item["TaskID_x003a_TaskName"],
    	item => item["TaskID_x003a_TaskAlias"],
    	item => item["TaskID_x003a_TaskDueTime"],
    	item => item["Daily_Frequency_x003a_DayofWeek"],
    	item => item["Weekly_Frequency_x003a_Week"],
    	item => item["End_Date"],
    	item => item["Monthly_Frequency"]));
    context.ExecuteQuery();
    
    foreach(ListItem spListItem in GetSharePointList){
    	//do something with the data
    }
