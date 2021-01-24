    //task object
    DynamicJsonObject toCreate = new DynamicJsonObject();    
    toCreate["WorkProduct"] = storyRef;
    //Tag Holder
    ArrayList tagArray = new ArrayList();
    
    //loop through your tags
    foreach(tag in tags)
    {
         DynamicJsonObject tagObj = new DynamicJsonObject();
         tagObj["_ref"] = tag._ref;
         tagArray.Add(tagObj);
    }
    //this is where you attach the tags
    toCreate["Tags"] = tagArray;  
    //call the API to create the task
    CreateResult result = api.Create(WorkSpace._ref,"task", toCreate );
