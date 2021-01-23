    Inside the controller(GET method):
    List<string> ListItems = new List<string>();
                ListItems.Add("Ms.");
                ListItems.Add("Mrs.");
                ListItems.Add("Mr.");
                ListItems.Add("Miss");
                SelectList Titles = new SelectList(ListItems);
                ViewData["Titles"] = Titles;
