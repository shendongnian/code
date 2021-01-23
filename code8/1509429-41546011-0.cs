    public class YourViewModel
    {
      private String _imageSource = "";
      public String ImageSource
      {
       get{return _imageSource;}
       set{_imageSource = value;
           NotifyPropertyChanged(m => m.ImageSource);
          }
      }
      private Int _sourceImageHeight = 0;
      public Int SourceImageHeight 
      {
       get{return _sourceImageHeight ;}
       set{_sourceImageHeight = value;
           NotifyPropertyChanged(m => m.SourceImageHeight);
          }
      }
    }
