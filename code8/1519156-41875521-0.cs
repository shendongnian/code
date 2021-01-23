    public static class ControlsExtensionMethods
    {
        public static Control FindControlRecursive(this Control root, string id)
        {
            if (id == string.Empty)
            {
                return null;
            }
            if (root.ID == id)
            {
                return root;
            }
                
            foreach (Control nestedControl in root.Controls)
            {
                Control foundedControlInNested = FindControlRecursive(nestedControl, id);
                if (foundedControlInNested != null)
                {
                    return foundedControlInNested;
                }
            }
            return null;
        }
    }
