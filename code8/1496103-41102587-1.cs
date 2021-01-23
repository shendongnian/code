    public class GalerieViewModel<TImage>
        where TImage : IGalerieModel {
        
        public new ObservableCollection<TImage> Images { get; set; }
    }
