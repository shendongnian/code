    public class MGradeFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            SetHasOptionsMenu(true);
            View view = LayoutInflater.From(Activity).Inflate(Resource.Layout.MGradesView, null);
            var entries = new[]
            {
                new Entry(200)
                {
                    Label = "January",
                    ValueLabel = "200",
                    Color = SKColor.Parse("#266489")
                },
                new Entry(400)
                {
                    Label = "February",
                    ValueLabel = "400",
                    Color = SKColor.Parse("#68B9C0")
                },
                new Entry(-100)
                {
                    Label = "March",
                    ValueLabel = "-100",
                    Color = SKColor.Parse("#90D585")
                }
            };
            var chart = new BarChart() { Entries = entries };
            var chartView = view.FindViewById<ChartView>(Resource.Id.chartView);
            chartView.Chart = chart;
            return view;
        }
        public override void OnCreateOptionsMenu(IMenu menu, MenuInflater inflater)
        {
            inflater.Inflate(Resource.Menu.menu_MGradeToolbar, menu);
        }
    }
