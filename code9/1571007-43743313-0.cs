    private void Button_Click(object sender, RoutedEventArgs e)
            {
                TextPointer cur = Rtb1.CaretPosition;
                char[] textbuffer = new char[1];
                do
                {
                    int offset = Rtb1.Document.ContentStart.GetOffsetToPosition(cur);
                    cur.GetTextInRun(LogicalDirection.Backward, textbuffer, 0, 1);
                    System.Diagnostics.Debug.WriteLine(textbuffer[0].ToString());
                    cur = cur.GetNextInsertionPosition(LogicalDirection.Backward);
                } while (textbuffer[0] != ' ' && cur != null);
    
                cur = cur.GetNextInsertionPosition(LogicalDirection.Forward);
                if (cur == null)
                    cur = Rtb1.Document.ContentStart;
                Rtb1.CaretPosition = cur;
                Rtb1.Focus();
                            
                Rect rect = cur.GetCharacterRect(LogicalDirection.Backward);
                Point point = Rtb1.PointToScreen(rect.BottomRight);
                Popup1.HorizontalOffset = point.X;
                Popup1.VerticalOffset = point.Y;
                Popup1.IsOpen = true;
            }
