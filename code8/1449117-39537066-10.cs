    public class MyTableCell : UITableViewCell
    	{
    		public delegate void DeleteCellHandler();
    		public event DeleteCellHandler DeleteCell;
    
    		UILabel lbTitle = new UILabel ();
    		UIButton btnDelete = new UIButton (UIButtonType.System);
    
    		public string Title{
    			get{ 
    				return lbTitle.Text;
    			}
    			set{ 
    				lbTitle.Text = value;
    			}
    		}
    
    		public MyTableCell (UITableViewCellStyle style, string reuseID) : base(style,reuseID)
    		{
    			lbTitle.Text = "";
    			lbTitle.Frame = new CoreGraphics.CGRect (0, 0, 100, 50);
    			this.AddSubview (lbTitle);
    
    			btnDelete.SetTitle ("Delete", UIControlState.Normal);
    			btnDelete.Frame = new CoreGraphics.CGRect (120, 0, 50, 50);
    			this.AddSubview (btnDelete);
    			btnDelete.TouchUpInside += delegate {
    				if(null != DeleteCell)
    					DeleteCell();
    			};
    		}
    	}
