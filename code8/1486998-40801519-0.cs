        private void OnGiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            if (e.Effects == DragDropEffects.Move 
                || e.Effects == DragDropEffects.Copy
                || e.Effects == DragDropEffects.Scroll)
            {
                e.UseDefaultCursors = false;
                Mouse.SetCursor(Cursors.Hand);
            }
            else
                e.UseDefaultCursors = true;
            e.Handled = true;
        }
