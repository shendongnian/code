       public testTable getParent(testTable item){
        	var parent=item;
        	while(true){
        	if(parent.PrID ==0)
        	break;
        	parent=dbo.testTables.SingleOrDefault(i => i.Id==parent.PrID)
        	}
        	return parent;
        }
        yourList.ToList().Select(item =>new{
        	isParentVisible=getParent(item).Visibility
        
        })
