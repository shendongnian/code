        public static void RemoveRecursive(XElement current, List<string> goodNames)
        {
            var parent = current;
            if (!goodNames.Contains(current.Name.ToString()))
            {
                parent = current.Parent;
                current.ReplaceWith(current.Elements());
            }
            foreach (var element in parent.Elements())
            {
                RemoveRecursive(element, goodNames);
            }
        }
