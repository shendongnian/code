    public class LoadInfoViewAdapter : BaseAdapter<Items>
    {
        private List<CondensedItems> cItems;
        private Context gContext;
	
        public LoadInfoViewAdapter(Context context, List<Items> loadinfo,  string LoadnStop)
        {        
            gContext = context;
            gLoadnStop = LoadnStop;
		
		    string uniqueItemNos = loadInfo.Select(x => x.ItemNo).Distinct();
		
		    cItems = new List<CondensedItem>();
		
		    foreach(string uniqueItem in uniqueItemNos)
		    {
			    var matchingItems = loadInfo.Select(x => x.ItemNo == uniqueItem).ToList();
			    var lineNo = matchingItems[0].LineNo;
			    var qty = matchingItems.Sum(x => x.Qty).ToString();
			
			    StringBuilder packsSB = new StringBuilder();
			
			    foreach(var item in matchingItems)
			    {
				    packs.Append(item.Pack + ",");
			    }
			
			    string packs = packsSB.ToString().Trim(',');
		
			    cItems.Add(
				    new CondensedItem 
				    {
					    ItemNo = uniqueItem,
					    LineNo = lineNo,
					    Packs = $"{qty}({packs})"
				    }
			    )  
		    }		
        }
        public override int Count
        {
            get { return cItems.Count; }
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override Items this[int position]
        {
            get { return cItems[position]; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;
		    CondensedViewHolder viewHolder;
		
            if (row == null)
            {
                row = LayoutInflater.From(gContext).Inflate(Resource.Layout.LoadInfoItems_Row, null);
			    row.FindViewById<TextView>(Resource.Id.txtItemNo)
			    viewHolder = new CondensedViewHolder 
			    {
			    	ItemView = row.FindViewById<TextView>(Resource.Id.txtItemNo),
				    LineView = row.FindViewById<TextView>(Resource.Id.txtLineNo),
				    PacksView = row.FindViewById<TextView>(Resource.Id.txtQuantity)
			    }
            }
            else
		    {
			    viewHolder = row.Tag as CondensedViewHolder;
		    }
		
		    viewHolder.ItemView.Text = cItems[position].ItemNo;
		    viewHolder.LineView.Text = cItems[position].LineNo;
		    viewHolder.PacksView.Text = cItems[position].Packs;
		
            return row;
        }
	
	    private class CondensedItem
	    {
		    string ItemNo { get; set; }
		    string LineNo { get; set; }
		    string Packs { get; set; }
	    }	
	
	    private class CondensedViewHolder : Java.Lang.Object
	    {
		    public TextView ItemView { get; set; }
		    public TextView LineView { get; set; }
		    public TextView PacksView { get; set; }
	    }
    }
