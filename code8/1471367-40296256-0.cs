    public SpriteSheet(string filename, int spriteWidth, int spriteHeight)
	{
		// Assign ID and get name
		this.textureID = GL.GenTexture();
		this.spriteSheetName = Path.GetFileNameWithoutExtension(filename);
		// Bind the Texture Array and set appropriate parameters
		GL.BindTexture(TextureTarget.Texture2DArray, textureID);
		GL.TexParameter(TextureTarget.Texture2DArray, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
		GL.TexParameter(TextureTarget.Texture2DArray, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
		GL.TexParameter(TextureTarget.Texture2DArray, TextureParameterName.TextureWrapS, (int)TextureWrapMode.ClampToEdge);
		GL.TexParameter(TextureTarget.Texture2DArray, TextureParameterName.TextureWrapT, (int)TextureWrapMode.ClampToEdge);
		// Load the image file
		Bitmap image = new Bitmap(@"Tiles/" + filename);
		BitmapData data = image.LockBits(new System.Drawing.Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
		// Determine columns and rows
		int spriteSheetwidth = image.Width;
		int spriteSheetheight = image.Height;
		int columns = spriteSheetwidth / spriteWidth;
		int rows = spriteSheetheight / spriteHeight;
		// Allocate storage
		GL.TexStorage3D(TextureTarget3d.Texture2DArray, 1, SizedInternalFormat.Rgba8, spriteWidth, spriteHeight, rows * columns);
		
		// Split the loaded image into individual Texture2D slices
		GL.PixelStore(PixelStoreParameter.UnpackRowLength, spriteSheetwidth);
		for (int i = 0; i < columns * rows; i++)
		{
			GL.TexSubImage3D(TextureTarget.Texture2DArray,
							 0, 0, 0, i, spriteWidth, spriteHeight, 1,
							 OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte,
							 data.Scan0 + (spriteWidth * 4 * (i % columns)) + (spriteSheetwidth * 4 * spriteHeight * (i / columns)));     // 4 bytes in an Bgra value.
		}
		image.UnlockBits(data);
	}
