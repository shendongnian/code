    public class MainActivity : Activity
    {
        Button btnDrapDrop;
        AbsoluteLayout layout;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Second);
            btnDrapDrop=FindViewById<Button>(Resource.Id.btnDrapDrop);
            layout = FindViewById<AbsoluteLayout>(Resource.Id.layout);
            
            //register the  long click event of drap button
            btnDrapDrop.LongClick += BtnDrapDrop_LongClick;
            //register the drag event of the layout
            layout.Drag += BtnDrapDrop_Drag;
        }
        private void BtnDrapDrop_Drag(object sender, View.DragEventArgs e)
        {
            AbsoluteLayout layout = (AbsoluteLayout)sender;
            switch (e.Event.Action)
            {
                case DragAction.Drop:
                    float x=e.Event.GetX();
                    float y = e.Event.GetY();
                    btnDrapDrop.TranslationX = x;
                    btnDrapDrop.TranslationY = y;
                    layout.Invalidate();
                    return;
            }
        }
        private void BtnDrapDrop_LongClick(object sender, Android.Views.View.LongClickEventArgs e)
        {
            ClipData dragData = ClipData.NewPlainText("", "");
            View.DragShadowBuilder myShadow = new View.DragShadowBuilder(btnDrapDrop);
            btnDrapDrop.StartDrag(dragData, myShadow, null, 0);
        }
    }
