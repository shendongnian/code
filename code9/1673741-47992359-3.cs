    public void AppendValues(List<int> ExData) {
        if(level==0){ 
            ExData.Add(value);
        } else{
            NW.AppendValues(ExData);
            NE.AppendValues(ExData);
            SW.AppendValues(ExData);
            SE.AppendValues(ExData);
        }
    }  
