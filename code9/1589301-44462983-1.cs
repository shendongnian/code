    public class Fragment2 : Fragment
    {
    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
       var view = inflater.Inflate(Resource.Layout.MySettingsView, container, false);
        ImageButton scanBtn = view.FindViewById<ImageButton>(Resource.Id.btnScan);
        TextView results = view.FindViewById<TextView>(Resource.Id.results);
        scanBtn.Click += async (sender, e) =>
        {
            MobileBarcodeScanner.Initialize(Activity.Application);
            var scanner = new MobileBarcodeScanner();
            var result = (ZXing.Result)null;
                
            result = await scanner.Scan();
            if (result == null)
            {
                scanner.AutoFocus();
                return;
            }
            Console.WriteLine($"Scanned Barcode: {result}");
            Activity.RunOnUiThread(() =>
            {
                results.Text = result.Text;
            });
        };
        return view;
    }
    }
