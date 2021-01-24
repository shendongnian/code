    public class CompanyRecyclerAdapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        
        void OnClick(int position)
        {
            if (ItemClick != null)
                ItemClick(this, position);
        }
        
        ...
 
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemview = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.Company, parent, false);
            CompanyViewHolder vh = new CompanyViewHolder(itemview, OnClick);
            return vh;
        }
    }
