        public ActionResult ArticleTypes(string at)
        {
            articleViewModel.Images = new List<ImageInfo>();
            var modelList = (from a in db.Articles
                         where a.SelectedArticleType == at
                         select new ArticlesViewModel
                         {
                             Id = a.Id,
                             Body = a.Body,
                             Headline = a.Headline,
                             PostedDate = a.PostedDate,
                             SelectedArticleType = a.SelectedArticleType,
                             UserName = a.UserName
                         }).ToList();
            
            foreach (var model in modelList)
            {
                model.Images = imageService.GetImagesForArticle(model.Id.ToString());
            }
            return View(modelList);
    }
