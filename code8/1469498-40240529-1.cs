    public class AllParams
    {
        public string Prop1 { get; set; }
        public string Prop2 { get; set; }
        public string Prop3 { get; set; }
        public string Prop4 { get; set; }
        public string Prop5 { get; set; }
        public string PropN { get; set; }
    }
    proxy.On<AllParams>("test", all =>
    {
        MyActivity.RunOnUiThread(() =>
        {
            // all.Prop1, all.Prop2, etc...
        });
    });
