    public class ListAdapter: BaseAdapter
	{
	
		// Make this variable global
		 TextView deliverNumberTextView ;
         CheckBox listviewCheckbox
		 public override View GetView (int position, View convertView, ViewGroup parent)
         { 
				View row = convertView;
 
				if (row == null)
				{ 
					row = LayoutInflater.From (_context).Inflate (Resource.Layout.ListviewRow, null, false);
				} 
 
					deliverNumberTextView = (TextView) row.FindViewById (Resource.Id.deliverNumberTextView);
 
					listviewCheckbox = (CheckBox)row.FindViewById(Resource.Id.listviewCheckbox);
 
					deliverNumberTextView.Text = _deliveries[position].DeliveryNumber;
					listviewCheckbox.Visibility = ViewStates.Visible;
 
        return row;
        } 
    }
