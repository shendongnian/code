      public class ViewModel : INotifyPropertyChanged
      {
        public ViewModel()
        {
          m_images = new ObservableCollection<MyImage>(
            new MyImage[] {
              new MyImage() { Color = Brushes.Red, Height = 100, Width = 70 },
              new MyImage() { Color = Brushes.Green, Height = 100, Width = 70 },
              new MyImage() { Color = Brushes.Blue, Height = 100, Width = 70 },
              new MyImage() { Color = Brushes.Yellow, Height = 100, Width = 70 },
              new MyImage() { Color = Brushes.Magenta, Height = 100, Width = 70 },
              new MyImage() { Color = Brushes.Cyan, Height = 100, Width = 70 }
              });
    
          foreach (var image in m_images)
          {
            image.PropertyChanged += Image_PropertyChanged;
          }
        }
    
        private void Image_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
          switch (e.PropertyName)
          {
            case "MouseIsOverMe":
    
              var curImage = sender as MyImage;
              var curIndex = m_images.IndexOf(curImage);
    
              if (curImage.MouseIsOverMe)
              {
                if (curIndex > 0)
                {
                  m_images[curIndex - 1].Width *= 1.2;
                  m_images[curIndex - 1].Height *= 1.2;
                }
                if (curIndex < m_images.Count - 2)
                {
                  m_images[curIndex + 1].Width *= 1.2;
                  m_images[curIndex + 1].Height *= 1.2;
                }
    
                m_images[curIndex].Width *= 1.5;
                m_images[curIndex].Height *= 1.5;
              }
              else
              {
                if (curIndex > 0)
                {
                  m_images[curIndex - 1].Width /= 1.2;
                  m_images[curIndex - 1].Height /= 1.2;
                }
                if (curIndex < m_images.Count - 2)
                {
                  m_images[curIndex + 1].Width /= 1.2;
                  m_images[curIndex + 1].Height /= 1.2;
                }
    
                m_images[curIndex].Width /= 1.5;
                m_images[curIndex].Height /= 1.5;
              }
              break;
            default:
              break;
          }
        }
    
        private ObservableCollection<MyImage> m_images;
        public ObservableCollection<MyImage> Images
        {
          get { return m_images; }
          set
          {
            m_images = value;
            OnPropertyChanged("Images");
          }
        }
    
    
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
      }
