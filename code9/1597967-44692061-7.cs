    FindViewById<Button>(Resource.Id.button_done).Click += delegate
        Intent intent = new Intent(this, typeof(MainActivity); //Added the type of Main Activity
        int put_position = get_position;
        intent.PutExtra("Main_Put_Edit_Position2", put_position);
        Console.WriteLine("put array edit position = " + put_position);
        string put_name = alarm_name.Text;
        intent.PutExtra("Main_Put_Edit_Name2", put_name);
        Console.WriteLine("put array edit name = " + put_name);
        SetResult(Result.Ok, intent); //added the SetResult method.
        Finish();
    };
