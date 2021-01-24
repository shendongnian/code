    using Microsoft.AspNetCore.Mvc;
    namespace LC.CompuTECH._2017.ViewComponents
    {
        public class ItemListViewComponent : ViewComponent
        {
            public ItemListViewComponent()
            {
            
            }
            public IViewComponentResult Invoke(string t)
            {
			    switch (t.ToUpper())
			    {
				    case "STUDENT":
					    this.Type = ListTypes.Student;
					    break;
				    case "WORK":
					    this.Type = ListTypes.Work;
					    break;
				    case "GAMER":
					    this.Type = ListTypes.Gamer;
					    break;
				    case "OTHER":
					    this.Type = ListTypes.Other;
					    break;
			    }
		
                return View();
            }
            public ListTypes Type { get; internal set; }
            public enum ListTypes
            {
                Student,
                Work,
                Gamer,
                Other
            }
        }
    }
