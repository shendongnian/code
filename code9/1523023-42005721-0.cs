    public static List<T> GetControls<T>(this Control _mainControl, int _maxDepth = 10) where T : Control
        {
            if (_maxDepth < 0)
                return new List<T>();
            List<T> ObjectList = new List<T>();
            foreach (Control CurrentControl in _mainControl.Controls)
            {
                if (CurrentControl is T)
                {
                    ObjectList.Add(CurrentControl as T);
                }
                else
                {
                    ObjectList.AddRange(CurrentControl.GetControls<T>((_maxDepth - 1)));
                }
            }
            return ObjectList;
        }
