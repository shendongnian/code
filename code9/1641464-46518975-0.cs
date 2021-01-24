        //Inside Function start
    public static QueryFilter q;
    private static QueryFilter setDynamicQuery(String fieldName,String Operator,String fieldValue)
    {
    q=new QueryFilter(fieldName, Operator, fieldValue);
    return q;
    }
    //Inside Function end
    
    //When calling in main method start
    QueryRequest existUserStoryRequest = new QueryRequest("HierarchicalRequirement");
    String existStoryFormattedIDLst="US23456!US23457!US23446";
    for(String StoryFormattedID:existStoryFormattedIDLst.split("!")){
    existUserStoryRequest.setQueryFilter(setDynamicQuery("ScheduleState", "=", StoryFormattedID));
    
    }
    //When calling in main method end
