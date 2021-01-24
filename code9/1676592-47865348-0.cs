    public class MainWindow : Window {
        private CoverP3D _cover; 
        CoverP3D Cover {
           get {
               if (null==_cover)
                   _cover = new CoverP3D();
               return _cover;
           }
        }
        
        ...
    }
