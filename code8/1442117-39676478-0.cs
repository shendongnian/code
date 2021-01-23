    /// <summary>
    /// Mimics the Type inheritance hierarchy for enums
    /// </summary>
    // Enum is a special class that cannot be used as a constraint, so instead use its parent interface IConvertible
    public class InheritanceHierarchy<T> where T : IConvertible
    {
        private Dictionary<T, InheritanceElement<T>> elements =
            new Dictionary<T, InheritanceElement<T>>();
        public void Add(T element, T parent)
        {
            var parentElement = parent.Equals(default(T)) ? null : elements[parent];
            elements.Add(element, new InheritanceElement<T>(element, parentElement));
        }
        /// <summary>
        /// Add parent for multiple children
        /// </summary>
        public void Add(T parent, params T[] elements)
        {
            foreach (var element in elements)
                Add(element, parent);
        }
        public bool IsSameOrSubclass(T element, T parent)
        {
            return ParentIndex(element, parent) != -1;
        }
        /// <summary>
        /// Get how many parents the element is from parent. If they don't relate return -1
        /// </summary>
        public int ParentIndex(T element, T parent)
        {
            // If the element is same as parent
            if (element.Equals(parent))
                return 0;
            // Loop through the chain of parents checking until it is either null or a match
            var actualParent = elements[element].parent;
            var parentIndex = 1;
            while (actualParent != null)
            {
                if (parent.Equals(actualParent.element))
                    return parentIndex;
                else
                {
                    actualParent = actualParent.parent;
                    parentIndex++;
                }
            }
            return -1;
        }
    }
    public class InheritanceElement<T> where T : IConvertible
    {
        public T element;
        public InheritanceElement<T> parent;
        public InheritanceElement(T element, InheritanceElement<T> parent)
        {
            this.element = element;
            this.parent = parent;
        }
    }
