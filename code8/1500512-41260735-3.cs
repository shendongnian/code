    // there are several ways to do this, but this is
    // just a simple way to avoid casting all over the 
    // code, and still have generics for better type safety
    interface IHtmlRenderer
    {
        void Append(StringBuilder html, object element);
    }
    interface IHtmlRenderer<T> : IHtmlRenderer where T : IItem
    {
        void Append(StringBuilder html, T element);
    }
    
    abstract class BaseHtmlRenderer<T> : IHtmlRenderer<T> where T : IItem
    {
        public void Append(StringBuilder html, object element)
        {
            // this is the only place where we will cast
            this.Append(html, (T)element);
        }
        abstract public void Append(StringBuilder html, T element);
    }
    
