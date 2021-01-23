    declare Model in cshtml
     
    @model yourNameSpace.YourModelName
    
    
    YourModelName.cs 
     
    public List<ClassName> ListOfObjects { get; set; }
     
     
    //Controller Level
    
    call  YourRepository return  
    List<ClassName> RepoMethodToGetListOfObjects();
    var listOfObjects = YourRepository.RepoMethodToGetListOfObjects();
    
    //then populate model 
    
     model.ListOfObjects = YourRepository listOfObjects
     
     //in your cshtml you will have 
    
      <td>@Html.DropDownList
      ("test",new SelectList(Model.ListOfObjects, "objectId", "Description"),
       new Dictionary<string, object> { { "id", "DropDownList" },
      {"onchange", "YourJavascriptFile.YourName.yourJavascriptFunctionName(this)" }     })</td>
      
      Javascript Function to get Value and Key back to controller
    
     YourName: {
    
                 yourJavascriptFunctionName: function(sel) {
              //1way     var value = sel.value;
                   var key = $("#DropDownList option:selected").text();
                   var selectedDropDownValue = getDropDownValue("DropDownList");
                   location.href = "/YourFolderName/YourController/SelectedDropDownValueLogic?dropdownValue=" +
                     selectedDropDownValue +
                   "&dropdownKey=" +
                   key;
                 },  
         	    },
    			
    			function getDropDownValue(name) {
                 return $("#" + name).val();
                }
    
    
    			
    Do Some More Controller Logic when Drop Down option Selected 
    
      public ActionResult SelectedDropDownValueLogic(string dropdownValue,string dropdownKey)
        {
    
    	   //Do Logic ..
    	      Func<AggregateClass, ModelClass> buildModel = x => new ModelClass()
                  {
                     Property = x.Property,
                  };
    	  
    	              etc.....ForEach(x => model.ListOfObjects.Add(buildModel(x))
    	   //Do Logic ..
