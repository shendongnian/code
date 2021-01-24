    public class MyListAdapter : Java.Lang.Object,IListAdapter
    {
        public int Count {
            get {
                //list view will show 10 lines of data
                return 10;
            }
        }
        public bool HasStableIds { get { return false; } }
        public bool IsEmpty { get { return false; } }
        public int ViewTypeCount { get { return 1; } }
        
        private Context context;
        private string uniqueData;
        //default constructor
        public MyListAdapter()
        { }
        //constructor with current context and the data you want to show in your listview
        public MyListAdapter(Context c,string data)
        {
            context = c;
            uniqueData = data;
        }
        public bool AreAllItemsEnabled()
        {
            return true;
        }
        public void Dispose()
        {
            this.Dispose();
        }
        public Java.Lang.Object GetItem(int position)
        {
            throw new NotImplementedException();
        }
        public long GetItemId(int position)
        {
            return 0;
        }
        public int GetItemViewType(int position)
        {
            return 1;
        }
        public View GetView(int position, View convertView, ViewGroup parent)
        {
            View et=convertView;
            if (et == null)
            {
                et = new TextView(context);
                (et as TextView).Text = uniqueData;
            }
            return et; 
        }
        public bool IsEnabled(int position)
        {
            return true;
        }
        public void RegisterDataSetObserver(DataSetObserver observer)
        {
            
        }
        public void UnregisterDataSetObserver(DataSetObserver observer)
        {
            
        }
    }
