    public class MouseManager
    {
        public void MoveCursor(int x, int y)
        {
            Win32.POINT p = new Win32.POINT
            {
                x = x,
                y = y
            };
    
            Win32.SetCursorPos(p.x, p.y);
        }
    
        public int GetX()
        {
            var p = Win32.GetCursorPosition();
            return p.x;
        }
    
        public int GetY()
        {
            var p = Win32.GetCursorPosition();
            return p.y;
        }
    
        public void Click()
        {
            Win32.MouseEvent(Win32.MouseEventFlags.LeftDown);
            Win32.MouseEvent(Win32.MouseEventFlags.LeftUp);
        }
    
        public void RightClick()
        {
            Win32.MouseEvent(Win32.MouseEventFlags.RightDown);
            Win32.MouseEvent(Win32.MouseEventFlags.RightUp);
        }
    
        public void DoubleClick()
        {
            Win32.MouseEvent(Win32.MouseEventFlags.LeftDown);
            Win32.MouseEvent(Win32.MouseEventFlags.LeftUp);
            Win32.MouseEvent(Win32.MouseEventFlags.LeftDown);
            Win32.MouseEvent(Win32.MouseEventFlags.LeftUp);
        }
    
        public void Scroll(int y)
        {
            Win32.Scroll(y);
        }
    
        public void ClickDown()
        {
            Win32.MouseEvent(Win32.MouseEventFlags.LeftDown);
        }
    
        public void ClickUp()
        {
            Win32.MouseEvent(Win32.MouseEventFlags.LeftUp);
        }
    }
