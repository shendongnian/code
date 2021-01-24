    public void DrawStatics(Block[,] blocks)
    {
        spriteBatch.Begin(
            WorldManager.Instance.currentWorld.camera,
            SpriteSortMode.Deferred,
            samplerState: SamplerState.PointClamp
        );
        foreach (Block block in blocks)
        {
            if (block != null)
            {
                // Not ignoring BlockID.Air
                spriteBatch.Draw(
                    texture: block.texture, // There should be a texture for BlockID.Air...
                    position: block.position,
                    color: Color.White, // ...or a block.color could be saved as a fallback.
                    sourceRectangle: new Rectangle(
                        block.index * 20, 0, block.index * 20 + 20, 20)
                );
            }
        }
        spriteBatch.End();
    }
