    public class ViewModel
    {
        private ModelClass model = new ModelClass();
        public string Name
        {
           get
           {
               return model.Name;
           }
           set
           {
               model.name = value;
           }
        }
    }
