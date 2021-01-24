        class MyJSInterface : Java.Lang.Object
        {
            Context context;
            public MyJSInterface(Context context)
            {
                this.context = context;
            }
            [Export]
            [JavascriptInterface]
            public void CallCamera()
            {
                Toast.MakeText(context, "Hello from C#", ToastLength.Short).Show();
                Intent intent = new Intent(MediaStore.ActionImageCapture);
                context.StartActivity(intent);
            }
        }
