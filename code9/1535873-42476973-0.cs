    public class MainActivity : Activity , IOnChildClickListener
        {
            ExpandableListView listView;
            List<Data> newDataList;
            ExpandableDataAdapter myadapter;
            public bool OnChildClick(ExpandableListView parent, View clickedView, int groupPosition, int childPosition, long id)
            {     
                newDataList.RemoveAt(0);
                myadapter.NotifyDataSetChanged();
                return true;
            }
    
            protected override void OnCreate (Bundle bundle)
    		{
    			base.OnCreate (bundle);
    			SetContentView (Resource.Layout.Main);       
                newDataList = Data.SampleData();
                myadapter = new ExpandableDataAdapter(this, newDataList);
                listView = FindViewById<ExpandableListView> (Resource.Id.myExpandableListview);
    			listView.SetAdapter (myadapter);
                listView.SetOnChildClickListener(this);
    
    
            }
    	}
