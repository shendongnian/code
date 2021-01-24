        public class ViewModel 
    {
        public IView View { get; set; }
    
        public void CreateDynamicWPFGrid() 
        {
            if (View == null)
            {
              return;
           } 
            View.CreateDynamicWPFGrid()
        }
    }
