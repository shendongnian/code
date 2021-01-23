    var pList = spanList.Where(p => p.ClassName == "p").ToList();
    var sList = spanList.Where(p => p.ClassName == "s").ToList();
    
    if(sList.Count == 2)
    {
    	string name = "";
    	string tag = "";
    	string taghref = "";
    
    	switch(pList.Count)
    	{
    		case 2:
    			name = pList[1].TextContent;
    			tag = adressList.Where(p => p.ClassName == "n").ToList()[1].TextContent;
    			taghref = adressList[1].GetAttribute("href");
    			break;
    		case 4:
    			name = pList[2].TextContent;
    			tag = pList[3].TextContent;
    			break;
            default:
                name = "error";
                break;
    	}
    	
    	lesson.lesson2Name = name;
    	lesson.lesson2Place = sList[1].TextContext;
    	lesson.lesson2Tag = tag;
    	lesson.lesson2TagHref = taghref;
    }
