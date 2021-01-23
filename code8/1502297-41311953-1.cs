    // Copy Graphics object from EventArgs
    Graphics g = e.Graphics;
    // Save the current Matrix of the Graphics object
    var currentMatrix = g.Save();
    // Reset the Matrix to Identity matrix
    g.Reset();
    // Move the text Position to 0/0 
    g.TranslateTransform(-textPosition.X, -textPosition.Y);
    // Torsten in origin
    g.RotateTransform(angle);
    // Move Back the drawing point
    g.TranslateTransform(textPosition.X, textPosition.Y);
    // Draw text
    g.DrawString(..);
    // restore saved Matrix.
    G.Restore(currentMatrix);
