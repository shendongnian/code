    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Windows.Media.Imaging;
    using Autodesk.Revit.DB;
    using Autodesk.Revit.UI;
    
    namespace BGPanel
    {
      public class CsBGPanel : IExternalApplication
      {
        public Result OnStartup(UIControlledApplication application)
        {
          RibbonPanel ribbonPanel = application.CreateRibbonPanel("Tools");
    
          string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;
          PushButtonData buttonData = new PushButtonData("cmdDeleteViews",
             "Delete Views", thisAssemblyPath, typeof(DeleteViews).FullName);
    
          PushButton pushButton = ribbonPanel.AddItem(buttonData) as PushButton;
    
          pushButton.ToolTip = "Delete all sheets, schedules & views except structural plans";
    
          Uri uriImage = new Uri(@"C:\Revit_API\Revit_2015\32px-Broom.png");
          BitmapImage largeImage = new BitmapImage(uriImage);
          pushButton.LargeImage = largeImage;
    
          return Result.Succeeded;
        }
    
        public Result OnShutdown(UIControlledApplication application)
        {
          return Result.Succeeded;
        }
      }
      
      public class DeleteViews : IExternalCommand
      {
        // this will not work...
        //public UIDocument ActiveUIDocument { get; private set; }
    
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
          UIDocument uidoc = commandData.Application.ActiveUIDocument; //this.ActiveUIDocument;
          Document doc = uidoc.Document;
    
          FilteredElementCollector collector = new FilteredElementCollector(doc);
          ICollection<Element> collection = collector.OfClass(typeof(View)).ToElements();
    
          using (Transaction t = new Transaction(doc, "Delete Views"))
          {
            t.Start();
    
            int x = 0;
    
            foreach (Element e in collection)
            {
              try
              {
                View view = e as View;
    
                switch (view.ViewType)
                {
                  case ViewType.FloorPlan:
                    break;
                  case ViewType.EngineeringPlan:
                    break;
                  case ViewType.ThreeD:
                    break;
                  default:
                    doc.Delete(e.Id);
                    x += 1;
                    break;
                }
              }
              catch (Exception ex)
              {
                View view = e as View;
                TaskDialog.Show("Error", e.Name + "\n" + "\n" + ex.Message);
                TaskDialog.Show("Error", ex.Message);
              }
            }
            t.Commit();
    
            TaskDialog.Show("BG_API DeleteViews", "Views Deleted: " + x.ToString());
          }
          return Result.Succeeded; // must return here
        }
      }
    }
