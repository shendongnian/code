    using System;
    using OpenTK;
    using OpenTK.Graphics;
    using OpenTK.Graphics.OpenGL;
    
    namespace OpenGLLine
    {
       static class Program
       {
          static OpenTK.GameWindow gw;
          static int shaderProgram;
          static int vertexInfo;
          static int lineVertexBuffer;
          static int vertexCount;
    
          [STAThread]
          static void Main()
          {
             gw = new OpenTK.GameWindow(800, 600, OpenTK.Graphics.GraphicsMode.Default, "Game", OpenTK.GameWindowFlags.FixedWindow);
             Initialize();
             gw.RenderFrame += Gw_RenderFrame;
             gw.Closed += Gw_Closed;
             gw.Run(60);
          }
    
          private static void Gw_Closed(object sender, EventArgs e)
          {
             CleanUp();
          }
    
          private static void Initialize()
          {
             int vshader = GL.CreateShader(ShaderType.VertexShader);
             GL.ShaderSource(vshader, @"#version 130
                in vec2 vPosition;
                void main()
                {
                   gl_Position = vec4(vPosition, -1.0, 1.0);
                }");
             GL.CompileShader(vshader);
             int fshader = GL.CreateShader(ShaderType.FragmentShader);
             GL.ShaderSource(fshader, @"#version 130
                out vec4 fragColor;
                void main()
                {
                   fragColor = vec4(1.0, 1.0, 1.0, 1.0);
                }");
             GL.CompileShader(fshader);
             shaderProgram = GL.CreateProgram();
             GL.AttachShader(shaderProgram, vshader);
             GL.AttachShader(shaderProgram, fshader);
             GL.LinkProgram(shaderProgram);
             GL.DetachShader(shaderProgram, vshader);
             GL.DetachShader(shaderProgram, fshader);
             GL.UseProgram(shaderProgram);
             lineVertexBuffer = GL.GenBuffer();
             Vector2[] lineVertices = { new Vector2(0, 0), new Vector2(.5f, .5f) };
             vertexCount = lineVertices.Length;
             GL.BindBuffer(BufferTarget.ArrayBuffer, lineVertexBuffer);
             GL.BufferData(BufferTarget.ArrayBuffer, System.Runtime.InteropServices.Marshal.SizeOf(lineVertices[0]) * vertexCount,
                lineVertices, BufferUsageHint.StreamDraw);
             vertexInfo = GL.GenVertexArray();
             GL.BindVertexArray(vertexInfo);
             int locVPosition = GL.GetAttribLocation(shaderProgram, "vPosition");
             GL.EnableVertexAttribArray(locVPosition);
             GL.VertexAttribPointer(locVPosition, 2, VertexAttribPointerType.Float, false,
                System.Runtime.InteropServices.Marshal.SizeOf(lineVertices[0]), 0);
             GL.BindVertexArray(0);
             GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
             GL.UseProgram(0);
          }
    
          static void CleanUp()
          {
    
             GL.DeleteProgram(shaderProgram);
             GL.DeleteVertexArray(vertexInfo);
             GL.DeleteBuffer(lineVertexBuffer);
          }
    
          private static void Gw_RenderFrame(object sender, OpenTK.FrameEventArgs e)
          {
             GL.ClearColor(Color4.Black);
             GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
             GL.BindBuffer(BufferTarget.ArrayBuffer, lineVertexBuffer);
             GL.UseProgram(shaderProgram);
             GL.BindVertexArray(vertexInfo);
             GL.DrawArrays(PrimitiveType.LineStrip, 0, vertexCount);
             GL.BindVertexArray(0);
             GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
             GL.UseProgram(0);
             gw.SwapBuffers();
          }
       }
    }
