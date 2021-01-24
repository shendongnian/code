    namespace PleaseWorkV1
    {
    [Activity(Label = "TimetableMenu")]
    public class TimetableMenu : Activity
    {
        public Button ClassTimetableButton;
        public Button PlacementTimetableButton;
        public Button DownloadCalBTN;
        public UserInstance User;
        public GetConnectionClass Connect = new GetConnectionClass();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.TimeTableMenu);
            ClassTimetableButton = FindViewById<Button>(Resource.Id.ClassTimeTableBTN);
            PlacementTimetableButton = FindViewById<Button>(Resource.Id.PlacementTimeTableBTN);
            DownloadCalBTN = FindViewById<Button>(Resource.Id.DownloadMonthBTN);
            User = JsonConvert.DeserializeObject<UserInstance>(Intent.GetStringExtra("User"));
            ClassTimetableButton.Click += async (sender, args) => await ClassOnClick();
            //ClassTimetableButton.Click += delegate
            //{
            //    ClassOnClick();
            //};
            PlacementTimetableButton.Click += delegate
            {
                PlacementOnClick();
            };
            DownloadCalBTN.Click += delegate
            {
                DownloadCalBTNOnClick();
            };
        }
        private async Task ClassOnClick()
        {
            var progressDialog = ProgressDialog.Show(this, "Loading", "Message", false);
            var MoveToTimeTable = new Intent(this, typeof(TimeTable));
            MoveToTimeTable.PutExtra("User", JsonConvert.SerializeObject(User));
            StartActivity(MoveToTimeTable);
            await Task.Delay(0)
                .ContinueWith(task => { StartActivity(MoveToTimeTable); });
            progressDialog.Hide();
        }
