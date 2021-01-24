	class RenderObject
	{
		public int X;
		public int Y;
		public int Width;
		public int Height;
		public virtual void Render()
		{
		   //This should NOT be called
		}
	}
	class RenderBox : RenderObject
	{
		public override void Render()
		{
			//This should be called
		}
	}
	class RenderText : RenderObject
	{
		public override void Render()
		{
			//This should be called
		}
	}
