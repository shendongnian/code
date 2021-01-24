    public class MergeAdapter : BaseAdapter
    {
        protected List<IListAdapter> pieces = new List<IListAdapter>();
        protected string noItemsText;
    
        public MergeAdapter()
        {
        }
    
        public void AddAdapter(IListAdapter adapter)
        {
            pieces.Add(adapter);
            adapter.RegisterDataSetObserver(new CascadeDataSetObserver());
        }
    
        private class CascadeDataSetObserver : DataSetObserver
        {
            public override void OnChanged()
            {
                base.OnChanged();
            }
    
            public override void OnInvalidated()
            {
                base.OnInvalidated();
            }
        }
    
        public override int Count
        {
            get
            {
                int total = 0;
                foreach (var piece in pieces)
                {
                    total += piece.Count;
                }
                if (total == 0 && noItemsText != null)
                {
                    total = 1;
                }
                return total;
            }
        }
    
        public override Java.Lang.Object GetItem(int position)
        {
            foreach (var piece in pieces)
            {
                int size = piece.Count;
                if (position < size)
                    return (piece.GetItem(position));
                position -= size;
            }
            return null;
        }
    
        public override int ViewTypeCount
        {
            get
            {
                int total = 0;
                foreach (var piece in pieces)
                {
                    total += piece.ViewTypeCount;
                }
                return (Java.Lang.Math.Max(total, 1));
            }
        }
    
        public override int GetItemViewType(int position)
        {
            int typeOffset = 0;
            int result = -1;
    
            foreach (var piece in pieces)
            {
                int size = piece.Count;
                if (position < size)
                {
                    result = typeOffset + piece.GetItemViewType(position);
                    break;
                }
                position -= size;
                typeOffset += piece.ViewTypeCount;
            }
            return result;
        }
    
        public override long GetItemId(int position)
        {
            foreach (var piece in pieces)
            {
                int size = piece.Count;
                if (position < size)
                {
                    return (piece.GetItemId(position));
                }
                position -= size;
            }
            return (-1);
        }
    
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            foreach (var piece in pieces)
            {
                int size = piece.Count;
                if (position < size)
                    return piece.GetView(position, convertView, parent);
                position -= size;
            }
            if (noItemsText != null)
            {
                TextView text = new TextView(parent.Context);
                text.Text = noItemsText;
                return text;
            }
            return null;
        }
    
        public void SetNoItemText(string text)
        {
            noItemsText = text;
        }
    
        public IListAdapter GetAdapter(int position)
        {
            foreach (var piece in pieces)
            {
                int size = piece.Count;
                if (position < size)
                    return piece;
                position -= size;
            }
            return null;
        }
    }
