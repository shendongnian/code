    GL.Enable(EnableCap.ScissorTest);
    GL.Scissor(view_start_x, view_start_y, view_end_x, view_end_y);
    // Assume matrix mode is modelview
    GL.PushMatrix();
    GL.Translate(0, -vertical_scroll, 0);
          // Draw the graphics affected by scrollbar
    GL.PopMatrix();
    
    GL.Disable(EnableCap.ScissorTest);
    // Draw rest of the 2d graphics
