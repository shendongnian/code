            private void SMS_test_Click(object sender, EventArgs e)
        {
            var context = Application.Context.ApplicationContext;
            String defaultSmsApp = Telephony.Sms.GetDefaultSmsPackage(context);
    //Add this to make your app default
            Intent intent = new Intent();
            intent.SetAction(Telephony.Sms.Intents.ActionChangeDefault);
            intent.PutExtra(Telephony.Sms.Intents.ExtraPackageName, context.PackageName);
            StartActivity(intent);
    //Save the message
            var values = new ContentValues();
            values.Put("address", "+982323855");
            values.Put("body", "Added via Xamarin");
            values.Put("read", false);
            values.Put("date", "1513071781");
            context.ContentResolver.Insert(Telephony.Sms.Sent.ContentUri, values);
            Toast.MakeText(this, "Message added : ", ToastLength.Long).Show();
    //Add this to revert the default app to what it previously was.
            intent = new Intent();
            intent.SetAction(Telephony.Sms.Intents.ActionChangeDefault);
            intent.PutExtra(Telephony.Sms.Intents.ExtraPackageName, defaultSmsApp);
            StartActivity(intent);
        }
