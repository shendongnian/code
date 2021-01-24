    [StructLayout(LayoutKind.Sequential)]
    public struct Vertex
    {
        public const int Stride = 16 + 16;
        public Vector4 Pos;
        public Color4 Color;
    }
    public class Mesh
    {
        private Vertex[] _vertices;
        private int[] _indices;
        private SharpDX.Direct3D11.Buffer _indexBuffer;
        private SharpDX.Direct3D11.Buffer _vertexBuffer;
        private VertexBufferBinding _vertexBufferBinding;
        public Mesh(Vertex[] vertices, int[] indices)
        {
            // save the vertices in a field
            _vertices = value;
            var vbd = new BufferDescription(
                SharpDX.Utilities.SizeOf<Vertex>() * _vertices.Length,
                ResourceUsage.Immutable,
                BindFlags.VertexBuffer,
                CpuAccessFlags.None,
                ResourceOptionFlags.None,
                0);
            // setup the vertex buffer
            _vertexBuffer = SharpDX.Direct3D11.Buffer.Create<Vertex>(DX11.Device, _vertices, vbd);
            // create the binding
            _vertexBufferBinding = new VertexBufferBinding(_vertexBuffer, Vertex.Stride, 0);
            _indices = value;
            var ibd = new BufferDescription(
                   sizeof(int) * _indices.Length,
                   ResourceUsage.Immutable,
                   BindFlags.IndexBuffer,
                   CpuAccessFlags.None,
                   ResourceOptionFlags.None,
                   0);
            // setup the index buffer
            _indexBuffer = SharpDX.Direct3D11.Buffer.Create<int>(DX11.Device, _indices, ibd);
        }
        // the SelectBuffers will select the right vertex buffer.
        // this could be combined with the Draw method, but I rather not
        // You should call this ones even when you draw multiple the same mesh.
        public void SelectBuffers()
        {
            DX11.Device.ImmediateContext.InputAssembler.SetVertexBuffers(0, _vertexBufferBinding);
            DX11.Device.ImmediateContext.InputAssembler.SetIndexBuffer(_indexBuffer, SharpDX.DXGI.Format.R32_UInt, 0);
        }
        public void Draw()
        {
            DX11.Device.ImmediateContext.DrawIndexed(_indices.Length, 0, 0);
        }
    }
---
    List<Mesh> _meshes = new List<Mesh>();
    public void SetupShaders()
    {
        vertexShaderByteCode = ShaderBytecode.CompileFromFile("MiniTri.fx", "VS", "vs_4_0", ShaderFlags.None, EffectFlags.None);
        vertexShader = new VertexShader(device, vertexShaderByteCode);
        pixelShaderByteCode = ShaderBytecode.CompileFromFile("MiniTri.fx", "PS", "ps_4_0", ShaderFlags.None, EffectFlags.None);
        ...... etc
    }
    public Mesh SetupMesh(object objectToDraw)
    {
        switch(.....)
        {
            // .. implement your beautiful switch ;-)
        }
        return new Mesh(vertices, indices);
    }
    public void Init()
    {
        SetupShaders();
        _meshes.Add(SetupMesh(new Dreieck(.....)));
        _meshes.Add(SetupMesh(new Viereck(.....)));
        _meshes.Add(SetupMesh(new Kreis(.....)));
    }
    public override void RenderScene(DrawEventArgs args)
    {
        Renderer.Device.ImmediateContext.ClearRenderTargetView(Renderer.RenderTargetView, new Color4(0.6f, 0, 0, 0));
        foreach(var mesh in _meshes)
        {
            mesh.SelectBuffers();
            mesh.Draw();
        }
        return;
    }
