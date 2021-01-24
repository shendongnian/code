    public class MyHolder : TreeNode.BaseNodeViewHolder
    {
        private Context mcontext;
    
        public MyHolder(Context context) : base(context)
        {
            mcontext = context;
        }
    
        public override View CreateNodeView(TreeNode p0, Java.Lang.Object p1)
        {
            var inflater = LayoutInflater.FromContext(mcontext);
            var view = inflater.Inflate(Resource.Layout.itemview, null, false);
            TextView tv = view.FindViewById<TextView>(Resource.Id.itemtv);
            var item = p1 as TreeItem;
            tv.Text = item.text;
            return view;
        }
    }
