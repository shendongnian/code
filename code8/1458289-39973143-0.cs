        public sealed class ExpandPanel : ContentControl
        {
           public event EventHandler ExpandStateChanged;
           ...
           public bool IsExpanded
           {
                get { return (bool)GetValue(IsExpandedProperty); }
                set
                {
                    SetValue(IsExpandedProperty, value);
                    if (ExpandStateChanged != null)
                    {
                        ExpandStateChanged(this,null);
                    }
                }
            }
        }
