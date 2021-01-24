        Button btnDrapDrop;
        ...
        btnDrapDrop.LongClick += BtnDrapDrop_LongClick;
        ...
        private void BtnDrapDrop_LongClick(object sender, Android.Views.View.LongClickEventArgs e)
        {
            ClipData dragData = ClipData.NewPlainText("", "");
            View.DragShadowBuilder myShadow = new View.DragShadowBuilder(btnDrapDrop);
            btnDrapDrop.StartDrag(dragData, myShadow, null, 0);
        }
