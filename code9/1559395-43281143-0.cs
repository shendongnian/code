            var uri = Android.Net.Uri.Parse("tel:"+number);
            var intent = new Intent(Intent.ActionCall);
            intent.SetData(uri);
            var activity = (MainActivity)Forms.Context;
            var listener = new ActivityResultListener(activity);
            const int RequestDirectPhoneCall = 2;
            var context = Forms.Context;
            if (IsIntentAvailable(context, intent))
            {
                Console.WriteLine("about to start phone call activity");
                        ((Activity)Forms.Context).StartActivityForResult(intent,RequestDirectPhoneCall);
                Console.WriteLine("phone call activity should now have finished");
                return listener.Task;               
            }
