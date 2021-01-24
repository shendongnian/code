    public class ViewModel
    {
        private ModelClass model = new ModelClass();
        public string Name
        {
           get
           {
               if(model.Name == null)
               {
                  return "NULL";
               }
               return model.Name;
           }
           set
           {
               model.name = value;
           }
        }
    }
