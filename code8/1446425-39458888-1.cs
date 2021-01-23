    public class MyImageRenderListener : IRenderListener {
        /** the byte array of the extracted images */
        private List<byte[]> _myImages;
        public List<byte[]> MyImages {
          get { return _myImages; }
        }
        /** the file names of the extracted images */
        private List<string> _imageNames;
        public List<string> ImageNames { 
          get { return _imageNames; }
        } 
    
        public MyImageRenderListener() {
          _myImages = new List<byte[]>();
          _imageNames = new List<string>();
        }
    
        [...]
         
        public void RenderImage(ImageRenderInfo renderInfo) {
          try {
            PdfImageObject image = renderInfo.GetImage();
            if (image == null || image.GetImageBytesType() == PdfImageObject.ImageBytesType.JBIG2) 
              return;
    
            _imageNames.Add(string.Format("Image{0}.{1}", renderInfo.GetRef().Number, image.GetFileType() ) );
            _myImages.Add(image.GetImageAsBytes());
          }
          catch
          {
          }
        }
    
        [...]      
    }
