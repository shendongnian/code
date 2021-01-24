    public static partial class XElementExtensions
    {
        /// <summary>
        /// Enumerates through all descendants of the given element, returning the topmost elements that match the given predicate
        /// </summary>
        /// <param name="root"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static IEnumerable<XElement> DescendantsUntil(this XElement root, Func<XElement, bool> predicate, bool includeSelf = false)
        {
            if (predicate == null)
                throw new ArgumentNullException();
            return GetDescendantsUntil(root, predicate, includeSelf);
        }
        static IEnumerable<XElement> GetDescendantsUntil(XElement root, Func<XElement, bool> predicate, bool includeSelf)
        {
            if (root == null)
                yield break;
            if (includeSelf && predicate(root))
            {
                yield return root;
                yield break;
            }
            var current = root.FirstChild<XElement>();
            while (current != null)
            {
                var isMatch = predicate(current);
                if (isMatch)
                    yield return current;
                // If not a match, get the first child of the current element.
                XElement next = (isMatch ? null : current.FirstChild<XElement>());
                if (next == null)
                    // If no first child, get the next sibling of the current element.
                    next = current.NextSibling<XElement>();
                // If no more siblings, crawl up the list of parents until hitting the root, getting the next sibling of the lowest parent that has more siblings.
                if (next == null)
                {
                    for (var parent = current.Parent as XElement; parent != null && parent != root && next == null; parent = parent.Parent as XElement)
                    {
                        next = parent.NextSibling<XElement>();
                    }
                }
                current = next;
            }
        }
        public static TNode FirstChild<TNode>(this XNode node) where TNode : XNode
        {
            var container = node as XContainer;
            if (container == null)
                return null;
            return container.FirstNode.NextSibling<TNode>(true);
        }
        public static TNode NextSibling<TNode>(this XNode node) where TNode : XNode
        {
            return node.NextSibling<TNode>(false);
        }
        public static TNode NextSibling<TNode>(this XNode node, bool includeSelf) where TNode : XNode
        {
            if (node == null)
                return null;
            for (node = (includeSelf ? node : node.NextNode); node != null; node = node.NextNode)
            {
                var nextTNode = node as TNode;
                if (nextTNode != null)
                    return nextTNode;
            }
            return null;
        }
    }
