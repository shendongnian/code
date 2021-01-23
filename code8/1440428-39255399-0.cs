    @model PagedList.IPagedList<New_MinecraftNews_Webiste_MVC.Models.ArticlesViewModel>
    @using PagedList.Mvc;
    @{
        ViewBag.Title = "Page title goes here";
    }
    
    @foreach (var article in Model) {
    
        <h1>@article.Headline</h1>
        <h2>@article.SelectedArticleType</h2>
    
    }
