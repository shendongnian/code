    [Serializable]
    public class ModelStateStore
    {
         public List<ModelStateData> {get;set;}
    }
    [Serializable]
    public class ModelStateData 
    {
         public string PropertyName {get;set;}
         public bool IsValid {get;set;}
         public string ErrorMessage {get;set;}
    }
