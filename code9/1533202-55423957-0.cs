        /// <summary>Dibuja un Circulo de Color con Texto Centrado que puede usarse como 'Logo' del Usuario.</summary>
		/// <param name="PicSize">Tamaño (pixeles) de la Imagen a Retornar</param>
		/// <param name="Brush">Color y Estilo del Circulo</param>
		/// <param name="Texto">Texto a escribir dentro del Circulo</param>
		/// <param name="Fuente">Fuente del Texto</param>
		/// <param name="BackColor">Color del Fondo y del Texto</param>
		/// <returns>Devuelve una Imagen con todos los elementos dibujados dentro.</returns>
		public static System.Drawing.Image DrawUserCircle(System.Drawing.Size PicSize, System.Drawing.Brush Brush, string Texto, System.Drawing.Font Fuente, System.Drawing.Color BackColor)
		{
			//Imagen Virtual sobre la que se dibuja y se retorna al final:
			System.Drawing.Image Canvas = new System.Drawing.Bitmap(PicSize.Width, PicSize.Height);
			System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(Canvas);
			//Tamaño del Circulo (rect):
			System.Drawing.Rectangle outerRect = new System.Drawing.Rectangle(-1, -1, Canvas.Width + 1, Canvas.Height + 1);
			System.Drawing.Rectangle rect = System.Drawing.Rectangle.Inflate(outerRect, -2, -2);
			//Todas las opciones en Alta Calidad:
			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
			g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
			g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			using (System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath())
			{
				//Fondo del Picture:
				g.FillRectangle(new System.Drawing.SolidBrush(BackColor),
					new System.Drawing.RectangleF(0, 0, PicSize.Width, PicSize.Height));
				//Dibuja el Circulo:
				path.AddEllipse(rect);
				g.FillPath(Brush, path);
				System.Drawing.SizeF stringSize = g.MeasureString(Texto, Fuente); //<- Obtiene el tamaño del Texto en pixeles																				  
				int posX = Convert.ToInt32((PicSize.Width - stringSize.Width) / 2); //<- Calcula la posicion para centrar el Texto
				int posY = Convert.ToInt32((PicSize.Height - stringSize.Height) / 2);
				// Dibuja el Texto:
				g.DrawString(Texto, Fuente, new System.Drawing.SolidBrush(BackColor), new System.Drawing.Point(posX, posY));
			}
			return Canvas;
		}
