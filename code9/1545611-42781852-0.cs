    public class Container : IEnumerable<Element>
    {
        List<Element> _elm = new List<Element>();
        List<Element> _add = new List<Element>();
        List<Element> _rem = new List<Element>();
    
        public void PendAdd(Element elm)
        {
            _add.Add(elm);
        }
    
        public void Pendrem(Element elm)
        {
            _rem.Remove(elm);
        }
    
        public IEnumerator<Element> GetEnumerator()
        {
            return _elm.GetEnumerator();
        }
    
        // This is called "explicit interface implementation", see
        // https://msdn.microsoft.com/en-us/library/ms173157.aspx
        IEnumerator IEnumerable.GetEnumerator()
        {
            // will call the "other" GetEnumerator()
            return GetEnumerator();
        }
    }
