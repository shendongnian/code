	public class MyControlDesigner : ControlDesigner {
		
		private DesignerActionListCollection _ActionLists;
		private MyControl myControl;
		
		public MyControlDesigner() : base() {
			_ActionLists = new DesignerActionListCollection();
			_ActionLists.AddRange(base.ActionLists);
			_ActionLists.Add(new MyActionList(this));
		}
		
		public override DesignerActionListCollection ActionLists {
			get {
				return _ActionLists;
			}
		}
		
		public override void Initialize(IComponent component) {
			base.Initialize(component);
			if (Control is MyControl) {
				myControl = (MyControl) Control;
			}
		}
		
		public class MyActionList : DesignerActionList {
			
			private MyControlDesigner Designer;
			
			public MyActionList(MyControlDesigner Designer) : base(Designer.Component) {
				this.Designer = Designer;
			}
			
			public string MyProperty {
				get {
					return Designer.myControl.MyProperty;
				}
				set {
					Designer.myControl.MyProperty = value;
				}
			}
			
			public override DesignerActionItemCollection GetSortedActionItems() {
				DesignerActionItemCollection items = new DesignerActionItemCollection();
				//Replace Behavior with your property's category (if applicable)
				items.Add(new DesignerActionPropertyItem("MyProperty", "My property", "Behavior", "This is my property in the designer"));
				return items;
			}
			
		}
		
	}
