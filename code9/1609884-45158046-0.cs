    public class Command : IExternalCommand
    	{
    		public Result Execute(
    		  ExternalCommandData commandData,
    		  ref string message,
    		  ElementSet elements)
    		{
    			UIApplication uiapp = commandData.Application;
    			UIDocument uidoc = uiapp.ActiveUIDocument;
    			Application app = uiapp.Application;
    			Document doc = uidoc.Document;
    
    			Selection sel1 = uidoc.Selection;
    			List<XYZ> tempXYZ = new List<XYZ>(1);
    			XYZ p1 = sel1.PickPoint();
    			XYZ p2 = null;
    
    			
    			//tempXYZ.Add(p3);
    		
    			ModelCurve visualLine = null;
    			using (TransactionGroup tGroup = new TransactionGroup(doc))
    			{
    				tGroup.Start();
    		
    				Redraw:
    				using (Transaction t = new Transaction(doc))
    				{					
    					t.Start("Step 1");
    
    					Line line = Line.CreateBound(p1, getP3(uidoc));
    					
    					Plane geomPlane = Plane.CreateByNormalAndOrigin(doc.ActiveView.ViewDirection, doc.ActiveView.Origin);
    					SketchPlane sketch = SketchPlane.Create(doc, geomPlane);
    					visualLine = doc.Create.NewModelCurve(line, sketch) as ModelCurve;
    					doc.Regenerate();
    					uidoc.RefreshActiveView();					
    					goto Redraw;
    					
    					t.Commit();		
    				}
    				tGroup.Commit();
    			}
    		return Result.Succeeded;
    		}
    
    		private XYZ getP3(UIDocument uidoc)
    		{
    			UIView uiview = GetActiveUiView(uidoc);
    			Rectangle rect = uiview.GetWindowRectangle();
    			System.Drawing.Point p = System.Windows.Forms.Cursor.Position;
    			System.Windows.Forms.Cursor.Position = new System.Drawing.Point(p.X, p.Y);
    			double dx = (double)(p.X - rect.Left) / (rect.Right - rect.Left);
    			double dy = (double)(p.Y - rect.Bottom) / (rect.Top - rect.Bottom);
    			IList<XYZ> corners = uiview.GetZoomCorners();
    			XYZ a = corners[0];
    			XYZ b = corners[1];
    			XYZ v = b - a;
    			XYZ p3 = a + dx * v.X * XYZ.BasisX + dy * v.Y * XYZ.BasisY;
    			return p3;
    		}
    		//Convert Document hiện hành thành UIView
    		private UIView GetActiveUiView(UIDocument uidoc)
    		{
    			Document doc = uidoc.Document;
    			View view = doc.ActiveView;
    			IList<UIView> uiviews = uidoc.GetOpenUIViews();
    			UIView uiview = null;
    
    			foreach (UIView uv in uiviews)
    			{
    				if (uv.ViewId.Equals(view.Id))
    				{
    					uiview = uv;
    					break;
    				}
    			}
    			return uiview;
    		}
    	}
