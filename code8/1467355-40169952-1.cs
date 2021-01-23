        public IEnumerable<Node> DescendantsAndSelf()
        {
            yield return this;
            if (Children != null)
            {
                foreach (Node child in Children)
                {
                    yield return child;
                }
            }
        }
