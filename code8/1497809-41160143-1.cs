    restaurantRecommendations.Select(item => new RecommenderItem()
            {
                Id = item.Id,
                Entity = item
            });
    dishRecommendations.Select(item => new RecommenderItem()
            {
                Id = item.Id,
                Entity = item
            });
