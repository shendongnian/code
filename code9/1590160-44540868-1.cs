    
    using System;
    using System.Drawing;
    
    namespace ScreenCapture
    {
    	class Texture2DDownload : IDisposable
    	{
    		private SharpDX.Direct3D11.Device m_pDevice;
    		private SharpDX.Direct3D11.Texture2D m_pDebugTexture;
    
    		public Texture2DDownload(SharpDX.Direct3D11.Device pDevice)
    		{
    			m_pDevice = pDevice;
    		}
    
    		/// <summary>
    		/// Compare all the relevant properties of the texture descriptions for both input textures.
    		/// </summary>
    		/// <param name="texSource">The source texture</param>
    		/// <param name="texDest">The destination texture that will have the source data copied into it</param>
    		/// <returns>true if the source texture can be copied to the destination, false if their descriptions are incompatible</returns>
    		public static bool TextureCanBeCopied(SharpDX.Direct3D11.Texture2D texSource, SharpDX.Direct3D11.Texture2D texDest)
    		{
    			if(texSource.Description.ArraySize != texDest.Description.ArraySize)
    				return false;
    
    			if(texSource.Description.Format != texDest.Description.Format)
    				return false;
    
    			if(texSource.Description.Height != texDest.Description.Height)
    				return false;
    
    			if(texSource.Description.MipLevels != texDest.Description.MipLevels)
    				return false;
    
    			if(texSource.Description.SampleDescription.Count != texDest.Description.SampleDescription.Count)
    				return false;
    
    			if(texSource.Description.SampleDescription.Quality != texDest.Description.SampleDescription.Quality)
    				return false;
    
    			if(texSource.Description.Width != texDest.Description.Width)
    				return false;
    
    			return true;
    		}
    
    		/// <summary>
    		/// Saves the contents of a <see cref="SharpDX.Direct3D11.Texture2D"/> to a file with name contained in <paramref name="filename"/> using the specified <see cref="System.Drawing.Imaging.ImageFormat"/>.
    		/// </summary>
    		/// <param name="texture">The <see cref="SharpDX.Direct3D11.Texture2D"/> containing the data to save.</param>
    		/// <param name="filename">The filename on disk where the output image should be saved.</param>
    		/// <param name="imageFormat">The format to use when saving the output file.</param>
    		public void SaveTextureToFile(SharpDX.Direct3D11.Texture2D texture, string filename, System.Drawing.Imaging.ImageFormat imageFormat)
    		{
    			// If the existing debug texture doesn't exist, or the incoming texture is different than the existing debug texture...
    			if(m_pDebugTexture == null || !TextureCanBeCopied(m_pDebugTexture, texture))
    			{
    				// Dispose of any existing texture
    				if(m_pDebugTexture != null)
    				{
    					m_pDebugTexture.Dispose();
    				}
    
    				// Copy the original texture's description...
    				SharpDX.Direct3D11.Texture2DDescription newDescription = texture.Description;
    
    				// Then modify the parameters to create a CPU-readable staging texture
    				newDescription.BindFlags = SharpDX.Direct3D11.BindFlags.None;
    				newDescription.CpuAccessFlags = SharpDX.Direct3D11.CpuAccessFlags.Read;
    				newDescription.OptionFlags = SharpDX.Direct3D11.ResourceOptionFlags.None;
    				newDescription.Usage = SharpDX.Direct3D11.ResourceUsage.Staging;
    
    				// Re-generate the debug texture by copying the new texture's description
    				m_pDebugTexture = new SharpDX.Direct3D11.Texture2D(m_pDevice, newDescription);
    			}
    
    			// Copy the texture to our debug texture
    			m_pDevice.ImmediateContext.CopyResource(texture, m_pDebugTexture);
    
    			// Map the debug texture's resource 0 for read mode
    			SharpDX.DataStream data;
    			SharpDX.DataBox dbox = m_pDevice.ImmediateContext.MapSubresource(m_pDebugTexture, 0, 0, SharpDX.Direct3D11.MapMode.Read, SharpDX.Direct3D11.MapFlags.None, out data);
    
    			// Create a bitmap that's the same size as the debug texture
    			Bitmap b = new Bitmap(m_pDebugTexture.Description.Width, m_pDebugTexture.Description.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
    
    			// Lock the bitmap data to get access to the native bitmap pointer
    			System.Drawing.Imaging.BitmapData bd = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
    
    			// Use the native pointers to do a native-to-native memory copy from the mapped subresource to the bitmap data
    			// WARNING: This might totally blow up if you're using a different color format than B8G8R8A8_UNorm, I don't know how planar formats are structured as D3D textures!
    			//
    			// You can use Win32 CopyMemory to do the below copy if need be, but you have to do it in a loop to respect the Stride and RowPitch parameters in case the texture width
    			// isn't on an aligned byte boundary.
    			MediaFoundation.MFExtern.MFCopyImage(bd.Scan0, bd.Stride, dbox.DataPointer, dbox.RowPitch, bd.Width * 4, bd.Height);
    
    			/// Unlock the bitmap
    			b.UnlockBits(bd);
    
    			// Unmap the subresource mapping, ignore the SharpDX.DataStream because we don't need it.
    			m_pDevice.ImmediateContext.UnmapSubresource(m_pDebugTexture, 0);
    			data = null;
    
    			// Save the bitmap to the desired filename
    			b.Save(filename, imageFormat);
    			b.Dispose();
    			b = null;
    		}
    
    		#region IDisposable Support
    		private bool disposedValue = false; // To detect redundant calls
    
    		protected virtual void Dispose(bool disposing)
    		{
    			if(!disposedValue)
    			{
    				if(disposing)
    				{
    				}
    
    				if(m_pDebugTexture != null)
    				{
    					m_pDebugTexture.Dispose();
    				}
    
    				disposedValue = true;
    			}
    		}
    
    		// TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
    		~Texture2DDownload() {
    			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
    			Dispose(false);
    		}
    
    		// This code added to correctly implement the disposable pattern.
    		public void Dispose()
    		{
    			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
    			Dispose(true);
    			GC.SuppressFinalize(this);
    		}
    		#endregion
    	}
    }
