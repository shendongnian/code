    class ExpandableListAdapter : BaseExpandableListAdapter { 
        ...
        public override View GetChildView(int groupPosition, int childPosition, bool isLastChild, View convertView, ViewGroup parent)
        {
           TextView txtListChild;
           ...
           txtListChild = (TextView)convertView.FindViewById(Resource.Id.lListItem);
           ...
           txtListChild.Text = childText;
        }
        return convertView;
    }
