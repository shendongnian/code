        Dictionary<int, Rectangle> _rectDict = new Dictionary<int, Rectangle>();
        int _maxCol = 10;
        private void AddRectangle(int i, int j)
        {
            Rectangle rect = new Rectangle();
            Grid.SetRow(rect, i);
            Grid.SetColumn(rect, j);
            rect.Fill = new SolidColorBrush(System.Windows.Media.Colors.AliceBlue);
            AnswerGrid.Children.Add(rect);
            
            _rectDict[i * _maxCol + j] = rect;
        }
        
        private void ChangeColour(int i, int j, Color color)
        {
            Rectangle rect = _rectDict[i * _maxCol + j];
            
            // Change colour of rect
        }
