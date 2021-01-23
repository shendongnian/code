    public override bool OnOptionsItemSelected(IMenuItem item)
    {
        Toast.MakeText(this, "Action selected: " + item.TitleFormatted,
            ToastLength.Short).Show();
    
        //if (item.TitleFormatted.ToString() == "Edit")
        //    StartActivity(typeof(Edit_Activity));
        //else if (item.TitleFormatted.ToString() == "Save")
        //    StartActivity(typeof(Save_Activity));
        if (item.TitleFormatted.ToString() == "Edit")
        {
            var newFragment = new Edit_Fragment();
            var ft = FragmentManager.BeginTransaction();
            ft.Replace(Resource.Id.myframe, newFragment);
            ft.Commit();
        }
        else if (item.TitleFormatted.ToString() == "Save")
        {
            var newFragment = new Save_Fragment();
            var ft = FragmentManager.BeginTransaction();
            ft.Replace(Resource.Id.myframe, newFragment);
            ft.Commit();
        }
    
        return base.OnOptionsItemSelected(item);
    }
