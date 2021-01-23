    public NewModel ToNewModel(this Model model){
        var newModel = new NewModel()
        newModel.Test1 = model.Test1;
        newModel.Test2 = model.Test2;
    }
