    Expression<Func<T,bool>> filter = null;
    
    if(any){
       filter = x => true;
    }
    
    if(Atlas){
       filter = d => ((d as DetectorStatu).Detector as Detector).EnabledDetectorTypes.Count(t => t.DetectorTypeID == 1) > 0
    }
    if(Phoenix){
       filter = d => ((d as DetectorStatu).Detector as Detector).EnabledDetectorTypes.Count(t => t.DetectorTypeID == 2 || t.DetectorTypeID == 3) > 0;
    }
