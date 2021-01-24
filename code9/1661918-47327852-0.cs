    protected override bool draw(Camera camera, DrawingReason drawingReason, ShadowMap shadowMap)
            {
                if (drawingReason != DrawingReason.Normal)
                    return true;
    
                camera.UpdateEffect(Effect);
                foreach (var item in Items)
                {
                    Effect.World = Matrix.BillboardRH(item.Target.Position + item.GetOffset(item), camera.Position, -camera.Up, camera.Front);
                    Effect.DiffuseColor = item.GetColor(item);
                    SpriteBatch.Begin(SpriteSortMode.Deferred, Effect.GraphicsDevice.BlendStates.NonPremultiplied, null, Effect.GraphicsDevice.DepthStencilStates.DepthRead, null, Effect.Effect);
                    SpriteBatch.DrawString(Font, item.Text, Vector2.Zero, Color.Black, 0, Font.MeasureString(item.Text) / 2, item.GetSize(item), 0, 0);
                    SpriteBatch.End();
                }
    
                Effect.GraphicsDevice.SetDepthStencilState(Effect.GraphicsDevice.DepthStencilStates.Default);
                Effect.GraphicsDevice.SetBlendState(Effect.GraphicsDevice.BlendStates.Opaque);
    
                return true;
            }
