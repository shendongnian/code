        [Activity(Label = "YourApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, IOnDateSetListener
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            var dateEditText = FindViewById<EditText>(Resource.Id.date_EditText);
            dateEditText.Text = DateTime.Now.ToShortDateString();
            dateEditText.Click += delegate
            {
                OnClickDateEditText();
            };
        }
        private void OnClickDateEditText()
        {
            var dateTimeNow = DateTime.Now;
            DatePickerDialog datePicker = new DatePickerDialog(this, this, dateTimeNow.Year, dateTimeNow.Month, dateTimeNow.Day);
            datePicker.Show();
        }
        public void OnDateSet(DatePicker view, int year, int month, int dayOfMonth)
        {
            FindViewById<EditText>(Resource.Id.date_EditText).Text = new DateTime(year, month, dayOfMonth).ToShortDateString();
        }
    }
