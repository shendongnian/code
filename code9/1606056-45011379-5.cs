    public class RecyclerViewAdapter : RecyclerView.Adapter, IFilterable
    {
        private List<Chemical> _originalData;
        private List<Chemical> _items;
        private readonly Activity _context;
        public Filter Filter { get; private set; }
        public RecyclerViewAdapter(Activity activity, IEnumerable<Chemical> chemicals)
        {
            _items = chemicals.OrderBy(s => s.Name).ToList();
            _context = activity;
            Filter = new ChemicalFilter(this);
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.Chemical, parent, false);
            ChemicalHolder vh = new ChemicalHolder(itemView);
            return vh;
        }
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ChemicalHolder vh = holder as ChemicalHolder;
            var chemical = _items[position];
            vh.Image.SetImageResource(chemical.DrawableId);
            vh.Caption.Text = chemical.Name;
        }
        public override int ItemCount
        {
            get { return _items.Count; }
        }
        public class ChemicalHolder{...
        private class ChemicalFilter{//Implement the Filter logic
     }
