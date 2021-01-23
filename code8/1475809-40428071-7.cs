    public static class MyExtensions{
        public static Model ToModel(this Entity entity){
            var model = new Model()
            model.Test1 = entity.Test1;
            model.Test2 = entity.Test2;
    		model.Test3 = entity.Test3;
    		
    		return model;
        }
    }
