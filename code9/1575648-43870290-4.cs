        public void FindChildControlsRecursive(Control control)
        {
            foreach (Control childControl in control.Controls)
            {
                // add .BaseType in the next line if it's a UserControl
                if (childControl.GetType() == typeof(T))
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
