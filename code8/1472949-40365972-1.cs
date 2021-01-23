      [assembly: Xamarin.Forms.Dependency (typeof (AndroidCustomAlert))]   
      public class AndroidCustomAlert : ICustomAlert
        {
          void ShowAlert(string message)
          {
            var builder = new AlertDialog.Builder(Xamarin.Forms.Forms.Context);
            builder.SetMessage(message);
            builder.SetPositiveButton("OK", (sender, args) => { });
            builder.SetCancelable(false);
            builder.Show();
          }
        }
