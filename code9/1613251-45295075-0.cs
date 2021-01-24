                GL.Begin(PrimitiveType.Quads);
                    GL.TexCoord2(0, 0); GL.Vertex2(0, 0);
                    GL.TexCoord2(0, 1); GL.Vertex2(0, 1);
                    GL.TexCoord2(1, 1); GL.Vertex2(1, 1);
                    GL.TexCoord2(1, 0); GL.Vertex2(1, 0);
                GL.End();
                m.Dispose();
