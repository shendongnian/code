    private void _textureView_Touch(object sender, View.TouchEventArgs e)
    {
        if (_camera != null)
        {
            var parameters = _camera.GetParameters();
            _camera.CancelAutoFocus();
            Rect focusRect = CalculateTapArea(e.Event.GetX(), e.Event.GetY(), 1f);
    
            if (parameters.FocusMode != Android.Hardware.Camera.Parameters.FocusModeAuto)
            {
                parameters.FocusMode = Android.Hardware.Camera.Parameters.FocusModeAuto;
            }
            if (parameters.MaxNumFocusAreas > 0)
            {
                List<Area> mylist = new List<Area>();
                mylist.Add(new Android.Hardware.Camera.Area(focusRect, 1000));
                parameters.FocusAreas = mylist;
            }
    
            try
            {
                _camera.CancelAutoFocus();
                _camera.SetParameters(parameters);
                _camera.StartPreview();
                _camera.AutoFocus(new AutoFocusCallBack());
    
                MarginLayoutParams margin = new MarginLayoutParams(new ViewGroup.LayoutParams(ViewGroup.LayoutParams.WrapContent,
                ViewGroup.LayoutParams.WrapContent));
                margin.SetMargins(focusRect.Left, focusRect.Top,
                    focusRect.Right, focusRect.Bottom);
                RelativeLayout.LayoutParams layoutParams = new RelativeLayout.LayoutParams(margin);
                layoutParams.Height = 200;
                layoutParams.Width = 200;
                _focusimg.LayoutParameters = layoutParams;
                _focusimg.Visibility = ViewStates.Visible;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.Write(ex.StackTrace);
            }
            //return true;
        }
        else
        {
            //return false;
        }
    }
