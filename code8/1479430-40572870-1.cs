    Button _button;
    DatePickerFragment _datePicker;
    protected override void OnCreate(Bundle bundle)
    {
        _button = FindViewById<Button>(Resource.Id.your_button_id);
        _button.Click += Button_OnClick;
    }
    void Button_OnClick(object sender, EventArgs eventArgs)
    {
        _datePicker = DatePickerFragment.NewInstance(delegate (DateTime date)
        {
            ViewModel.GameStartDate = date;
        });
        _datePicker.Show(FragmentManager, DatePickerFragment.TAG);
    }
