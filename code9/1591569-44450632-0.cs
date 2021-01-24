	public interface IRenderer
	{
		void Render(TreeNode node);
	}
	
	class NoEditNode : TreeNode
	{
		IRenderer renderer = new RenderEditNode();
		public void Render()
		{
			renderer.Render(this);
		}
	}
	
	class RenderEditNode :  IRenderer
	{
		public void Render(TreeNode node)
		{
		/*	
		...
		*/
		}
	}
	
	
	class PersonNode : TreeNode
	{
		IRenderer renderer;
		
		public PersonNode(IRenderer renderer)
		{
			this.renderer = renderer;
		}
		
		public void Render()
		{
			renderer.Render(this);
		}
	}
	
	class RenderPersonNode :  IRenderer
	{
		public void Render(TreeNode node)
		{
			/*	
			...
			*/
		}
	}
