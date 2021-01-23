    private void Btn_Touch(object sender, Android.Views.View.TouchEventArgs e)
    {
        if (e.Event.Action == Android.Views.MotionEventActions.Down)
        {
            //do something immediately after touch the button
        }
        if (e.Event.Action == Android.Views.MotionEventActions.Up)
        {
            //do something after placing off your finger
        }
    }
