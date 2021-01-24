    listView.OnItemClickListener = new MyListener(this);
    public class MyListener : Java.Lang.Object, AdapterView.IOnItemClickListener
    {
        private MainActivity mainActivity;
        public MyListener(MainActivity mainActivity)
        {
            this.mainActivity = mainActivity;
        }
        public void OnItemClick(AdapterView parent, View view, int position, long id)
        {
            view.Selected = true;
        }
    }
