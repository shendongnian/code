    internal sealed class MyUserControlDesigner : ParentControlDesigner
	{
		IDesignerHost designerHost;
		public override void Initialize(IComponent component)
		{
			base.Initialize(component);
			base.AutoResizeHandles = true;
			base.EnableDesignMode(((MyUserControl)component).PanelContent, "ContentPanel");
			designerHost = (IDesignerHost)component.Site.GetService(typeof(IDesignerHost));
		}
		public override bool CanParent(Control control)
		{
			return false;
		}
		public override System.Collections.ICollection AssociatedComponents
		{
			get
			{
				List<Control> list = new List<Control>();
				foreach (Control control in ((MyUserControl)Control).PanelContent.Controls)
				{
					list.Add(control);
				}
				return list;
			}
		}
		protected override Control GetParentForComponent(IComponent component)
		{
			return ((MyUserControl)Control).PanelContent;
		}
		public override int NumberOfInternalControlDesigners()
		{
			return 1;
		}
		public override ControlDesigner InternalControlDesigner(int internalControlIndex)
		{
			Control panel = ((MyUserControl)Control).PanelContent;
			switch (internalControlIndex)
			{
				case 0:
					return this.designerHost.GetDesigner(panel) as ControlDesigner;
				default:
					return null;
			}
		}
		protected override IComponent[] CreateToolCore(ToolboxItem tool, int x, int y, int width, int height, bool hasLocation, bool hasSize)
		{
			ParentControlDesigner panelDesigner = this.designerHost.GetDesigner(((MyUserControl)Control).PanelContent) as ParentControlDesigner;
			InvokeCreateTool(panelDesigner, tool);
			return null;
		}
	}
