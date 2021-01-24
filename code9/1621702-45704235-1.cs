    protected override void OnResume()
    {
         base.OnResume();
         SetRecyclerAdaptor();
    }
    private void SetRecyclerAdaptor()
    {
         mainMenuRecyclerAdapter = new MainMenuRecyclerAdapter(lstMenu);
         mainMenuRecyclerAdapter.ItemClick += (sender, e) =>
         {
              Toast.MakeText(this,"Click happened here!",ToastLength.Short).Show();
         };
         recyclerView.SetAdapter(mainMenuRecyclerAdapter);
    }
