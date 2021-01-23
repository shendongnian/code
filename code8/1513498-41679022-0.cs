    public ActionResult Index() {
        string categorie = "--Tout--";
        string souscategorie = "--Tout--";
    
        if (Session["Categorie"] != null) {
            categorie = Session["Categorie"].ToString();
        }
    
        if (Session["SousCategorie"] != null) {
            souscategorie = Session["SousCategorie"].ToString();
        }
    
        SelectList cats = new SelectList(GetCategories(), categorie);
        SelectList sCats = new SelectList(GetSousCategories(), souscategorie);
    
        ViewBag.CategoriesList = cats;
        ViewBag.SousCategoriesList = sCats;
    
        using(DAL.WebShopEntities entities = new WebShopEntities()) {
            return View(entities.Article.ToList());
        }
    }
    @Html.Label("Catégories")
    @Html.DropDownList("Categories", (SelectList)ViewBag.CategoriesList, new { @class = "form-control dropdownlist" })
    
    <br />
    
    @Html.Label("Sous-Catégories")
    @Html.DropDownList("SousCategories", (SelectList)ViewBag.SousCategoriesList, new { @class = "form-control dropdownlist" })
