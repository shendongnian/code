    public class MainViewModel : INotifyPropertyChanged
    {
        private string encodedImage;
        public string EncodedImage
        {
            get
            {
                return encodedImage;
            }
            set
            {
                encodedImage = value;
                // Convert source to writeblebitmap and set value to SelectedImage
                ConvertToImage(value);
                NotifyPropertyChanged("EncodedStream");
            }
        }
        private WriteableBitmap selectedImage;
        public WriteableBitmap SelectedImage
        {
            get { return selectedImage; }
            private set { selectedImage = value; NotifyPropertyChanged("SelectedImage"); }
        }
        /// <summary>
        /// Convert encoded string to writeblebitmap
        /// set result value to SelectedImage
        /// </summary>
        /// <param name="base64String"></param>
        public async void ConvertToImage(string base64String)
        {
            byte[] bytes = Convert.FromBase64String(base64String);
            InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream();
            await stream.WriteAsync(bytes.AsBuffer());
            stream.Seek(0);
            BitmapDecoder decoder = await BitmapDecoder.CreateAsync(stream);       
            WriteableBitmap writebleBitmap = new WriteableBitmap((int)decoder.PixelWidth, (int)decoder.PixelHeight);
            await writebleBitmap.SetSourceAsync(stream);
            // When SelectedImage value is changed, it will notify the front end
            SelectedImage = writebleBitmap;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
