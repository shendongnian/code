    public JsonResult test()
    {
        var model = new Model()
    
        //{  Fill your model properties  }
        var response = new ResponseDTO<NewModel>(); //Declare the response of the type of your new design
        response.Result = model.ToNewModel();
    }
