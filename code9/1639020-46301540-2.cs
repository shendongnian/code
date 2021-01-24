      public class EntryCustomRenderer : EntryRenderer
        {
            protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
    
            if (Control != null)
            {
                Control.SetBackgroundColor(global::Android.Graphics.Color.Transparent);
    
                // set the cursor color the same as the entry TextColor
                IntPtr IntPtrtextViewClass = JNIEnv.FindClass(typeof(TextView));
                IntPtr mCursorDrawableResProperty = 
                       JNIEnv.GetFieldID(IntPtrtextViewClass, "mCursorDrawableRes", "I");
                // replace 0 with a Resource.Drawable.my_cursor 
                JNIEnv.SetField(Control.Handle, mCursorDrawableResProperty, 0); 
            }
        }
    }
