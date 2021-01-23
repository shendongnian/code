      [assembly: Xamarin.Forms.Dependency (typeof (AndroidCustomAlert))]   
      public class AndroidCustomAlert : ICustomAlert
        {
          void ShowAlert(string message)
          {
            var builder = new AlertDialog.Builder(Application.Context);
            builder.SetMessage(message);
            builder.SetCancelable(false);
            builder.Show();
          }
        }
