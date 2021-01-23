    private int _xPad, _yPad, _xDelta, _yDelta;
    prviate bool _moved;
    
    InfoBtn.Touch += (v, me) => //InfoBtn is a button within a frameLayout
    {
    	int X = (int)me.Event.RawX;
    	int Y = (int)me.Event.RawY;
    	switch (me.Event.Action & MotionEventActions.Mask)
    	{
    		case MotionEventActions.Down:
    			_xPad = frameLayout.PaddingLeft;
    			_yPad = frameLayout.PaddingTop;
    			_xDelta = X;
    			_yDelta = Y;
    			_moved = false;
    			break;
    		case MotionEventActions.Up:
    			if (!_moved)
    			{
    				//On Button Click
    			}
    			break;
    		case MotionEventActions.PointerDown:
    			break;
    		case MotionEventActions.PointerUp:
    			break;
    		case MotionEventActions.Move:
    			var _x = X - _xDelta;
    			var _y = Y - _yDelta;
    			_moved = _moved || Math.Abs(_x) > 100 || Math.Abs(_y) > 100; //100px
    			if (_moved)
    			{
    				var padleft = _x - _xPad;
    				padleft = padleft + InfoBtn.Width > Resources.DisplayMetrics.WidthPixels ? Resources.DisplayMetrics.WidthPixels - InfoBtn.Width : padleft;
    				var padtop = _y - _yPad;
    				padtop = padtop + InfoBtn.Height > Resources.DisplayMetrics.HeightPixels ? Resources.DisplayMetrics.HeightPixels - InfoBtn.Height : padtop;
    				frameLayout.SetPadding(0, 0, padleft, padtop);
    			}
    			break;
    	}
    	frameLayout.Invalidate();
    };
