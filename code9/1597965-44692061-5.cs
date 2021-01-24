    protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
    {
        base.OnActivityResult(requestCode, resultCode, data);
        if (resultCode == Result.Ok) {
            string put_name = data.GetStringExtra("Main_Put_Edit_Name2");
            int put_position = data.GetIntExtra("Main_Put_Edit_Position2");
        }
    }
