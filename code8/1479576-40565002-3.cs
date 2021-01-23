      public class MyImage : INotifyPropertyChanged
      {
        private double m_width;
        public double Width
        {
          get { return m_width; }
          set
          {
            m_width = value;
            OnPropertyChanged("Width");
          }
        }
    
        private double m_height;
        public double Height
        {
          get { return m_height; }
          set
          {
            m_height = value;
            OnPropertyChanged("Height");
          }
        }
    
        private Brush m_color;
        public Brush Color
        {
          get { return m_color; }
          set
          {
            m_color = value;
            OnPropertyChanged("Color");
          }
        }
    
        private bool m_mouseIsOverMe;
        public bool MouseIsOverMe
        {
          get { return m_mouseIsOverMe; }
          set
          {
            m_mouseIsOverMe = value;
            OnPropertyChanged("MouseIsOverMe");
          }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
      }
