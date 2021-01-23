    public static class XElementExtensions {
        public static bool EqualsIgnoreCase(this XName name1, XName name2) {
            return name1.Namespace == name2.Namespace &&
                name1.LocalName.Equals(name2.LocalName, StringComparison.OrdinalIgnoreCase);
        }
        public static XElement GetChild(this XElement e, XName name) {
            return e.EnumerateChildren(name).FirstOrDefault();
        }
        public static IEnumerable<XElement> EnumerateChildren(this XElement e, XName name) {
            return e.Elements().Where(i = > i.Name.EqualsIgnoreCase(name));
        }
    }
