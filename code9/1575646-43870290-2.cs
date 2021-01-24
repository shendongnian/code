        public void FindChildControlsRecursive(Control control)
        {
            foreach (Control childControl in control.Controls)
            {
                if (childControl.GetType().BaseType == typeof(T))
                {
                    _foundControls.Add((T)childControl);
                }
                else
                {
                    FindChildControlsRecursive(childControl);
                }
            }
        }
        private readonly List<T> _foundControls = new List<T>();
        public IEnumerable<T> FoundControls
        {
           get { return _foundControls; }
        }   
