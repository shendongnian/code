    var obj = CCU_O.MWT.DRSa09_DrEmrgOpn.DRSa09_DrEmrgOpnCst;
    for(int i = 0; i < yourCount; i++){
    	var prop = obj.GetType().GetProperties().FirstOrDefault(x => x.Name == string.Format("DCU{0}_IEmergOpenAct", i));
    
    	if(prop != null){
    		var propValue = (YourObjectType)prop.GetValue(CCU_O.MWT.DRSa09_DrEmrgOpn.DRSa09_DrEmrgOpnCst);    
    		propValue.Force(False);
    	}
    }
