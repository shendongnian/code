    //Here does a new thread start->
    IGraphicsContext control2Context = new GraphicsContext(GraphicsMode.Default,glControl2.WindowInfo);
    while(true)
    {
        glControl1.MakeCurrent()
        //render
        GL.Flush();
        glControl1.SwapBuffers();
        
        control2Context.MakeCurrent(glControl2.WindowInfo);
        //render
        GL.Flush();
        glControl2.SwapBuffers();
    }
