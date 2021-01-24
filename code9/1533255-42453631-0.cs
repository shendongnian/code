    public class MainActivity : Activity, ReminderDateDialog.OnNewDatePass,ReminderTimeDialog.OnNewTimePass//,taskedit_BaseFragment.OnChangeAddDataPass
    {
        DateTime _tempDateTime = DateTime.MinValue;
        ReminderDateDialog dateDialog;// use a variable to temporarily store the date dialog
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            SetContentView(Resource.Layout.Main);
            var btnChange =FindViewById<Button>(Resource.Id.ReallySurelyAButton);
            btnChange.Click += delegate
            {
                openDateDialog(3,bundle);
            };
        }
        public void closeTimeDialog(ReminderTimeDialog dialog)
        {
            FragmentTransaction ft = FragmentManager.BeginTransaction();
             ft.Remove(dialog);
             ft.AddToBackStack("close-time");
             dialog.Dismiss();
            dateDialog.Dismiss();// dismiss the date dialog after the time dialog;
        }
        ...
    }
