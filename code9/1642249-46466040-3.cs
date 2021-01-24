     public void Exist()
     {
         Android.Support.V7.App.AlertDialog.Builder alert = new Android.Support.V7.App.AlertDialog.Builder(this);
         alert.SetTitle("");
     }
     public void Regist()
     {
         Intent intent = new Intent(this, typeof(RegisterDone));
         StartActivity(intent);
     }
