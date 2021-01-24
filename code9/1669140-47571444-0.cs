    public void batchDraw(int x, int y, int w, int h, float tx, float ty, float tw, float th)
    {
        float[] vpos = new float[] { x, y, x + w, y, x, y + h, x + w, y + h };
        float[] vtxc = new float[] { tx, ty + th, tx + tw, ty + th, tx , ty, tx + tw, ty };
        GL.VertexPointer(2, VertexPointerType.Float, 0, vpos);
        GL.EnableClientState(ArrayCap.VertexArray);
        GL.TexCoordPointer(2, TexCoordPointerType.Float, 0, vtxc);
        GL.EnableClientState(ArrayCap.TextureCoordArray);
        //Sometimes Error at DrawArrays: AccessViolationException
        GL.DrawArrays(PrimitiveType.TriangleStrip, 0, 4);
        GL.DisableClientState(ArrayCap.VertexArray);
        GL.DisableClientState(ArrayCap.TextureCoordArray);
    }
