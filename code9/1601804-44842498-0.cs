    return articles
        .Select(entity => new OrderCateringArticleViewModel
        {
            ArticleId = entity.Id, ImagePath = entity.ImagePath
        })
        .Where(entity => !(entity.HideUntilDate != null && entity .HideUntilDate.Value > DateTime.Today));
