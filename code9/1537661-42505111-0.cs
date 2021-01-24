       public class TestViewModel: PropertyChangedBase
        {
    
            private string _name = "Superman1";
            public string Name
            {
                get { return _name; }
                set
                {
                    _name = value;
                    NotifyOfPropertyChange(() => Name);
                }
            }
    
    
            private string _psition;
            public string Position
            {
                get { return _psition; }
                set
                {
                    _psition = value;
                    NotifyOfPropertyChange(() => Position);
                }
            }
    
    
            public void NameChanged()
            {
                Name = "Batman";
            }
    
    
            public void MouseMoveHandler(object sender, MouseEventArgs e)
            {
                Point p = e.GetPosition((Grid)sender);
    
                Position = string.Format("X:{0}  Y:{1}", p.X, p.Y);
            }
    
        }
