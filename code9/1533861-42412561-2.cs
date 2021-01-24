    public class MainActivity : ListActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            var data = new DataSource();
    
            ListAdapter = new MainAdapter(this, data.result);
        }
    }
