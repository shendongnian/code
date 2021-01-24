        public static bool SelectElementContainsItemText(SelectElement selElem, string itemText)
        {
            bool found = false;
            for (int i = 0; i < selElem.Options.Count; i++)
            {
                var blah = selElem.Options[i].Text;
                if (selElem.Options[i].Text.Equals(itemText))
                {
                    found = true;
                    break;
                }
            }
            return found;
        }
