    using System;
    using System.Collections.Generic;
    using System.Windows.Input;
    
    namespace MyNamespace
    {
        public class OverrideCursor : IDisposable
        {
            static Stack<Cursor> s_Stack = new Stack<Cursor>();
    
            public OverrideCursor(Cursor changeToCursor = null)
            {
                if (changeToCursor == null)
                    changeToCursor = Cursors.Wait;
    
                s_Stack.Push(changeToCursor);
    
                if (Mouse.OverrideCursor != changeToCursor)
                    Mouse.OverrideCursor = changeToCursor;
            }
    
            public void Dispose()
            {
                s_Stack.Pop();
                var cursor = _stack.Count > 0 ? _stack.Peek() : null;
                if (Mouse.OverrideCursor != cursor)
                    Mouse.OverrideCursor = cursor;
    
            }
        }
    }
