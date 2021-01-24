    public class CustomQueue : Queue<object>
    {
        public event EventHandler FirstItemInserted;
        protected virtual void OnFirstItemInserted()
        {
            FirstItemInserted?.Invoke(this, EventArgs.Empty);
        }
        //Modified Enqueue method.
        public new void Enqueue(object obj)
        {
            //Call the listener every time an item is inserted into the empty queue.
            if (Count == 0)
            {
                base.Enqueue(obj);
                OnFirstItemInserted();
            }
            else
                base.Enqueue(obj);
        }
    }
