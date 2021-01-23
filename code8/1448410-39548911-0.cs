     public class DiamondListingPage : PageBase
     {
          public View3x3Tile View3x3Tile { get; set; } = MyPages.View3x3Tile;
          public CombTableView CombTableView { get; set; } = MyPages.CombTableView;
          public TableView TableView { get; set; } = MyPages.TableView;
     
          public IEnumerable<PageBase> SubPagesList() {
              yield return View3xTitle;
              yield return CombTableView;
              yield return TableView;
          }
     }
