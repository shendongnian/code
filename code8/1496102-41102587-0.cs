    public class GalerieViewModel {
        
        public String WindowTitle { get; set; }
        public String WelcomeMessage { get; set; }
        public virtual ObservableCollection<IGalerieModel> Images { get; set; }
    }
