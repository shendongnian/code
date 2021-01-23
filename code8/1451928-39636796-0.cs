    public override bool OnTouchEvent(MotionEvent e)
        {
             InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
             imm.HideSoftInputFromWindow(Etusername.WindowToken, 0);
             return base.OnTouchEvent(e);
        }
