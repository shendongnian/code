            if (!Cheacked)
            {
                IEnumerable<CheckBox> _CheackBox = FindVisualChildren<CheckBox>(this);
                foreach (CheckBox _CB in _CheackBox)
                {
                    _CB.IsChecked = true;
                }
            }
            else
            {
                IEnumerable<CheckBox> _CheackBox = FindVisualChildren<CheckBox>(this);
                foreach (CheckBox _CB in _CheackBox)
                {
                    _CB.IsChecked = false;
                }
            }
