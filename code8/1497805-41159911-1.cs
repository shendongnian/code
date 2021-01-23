    public List<RecommenderItem> GetMergedRecommendationLists(List<Restaurant> restaurantRecommendations, List<Dish> dishRecommendations)
    {
        //Setting up the output list.
        List<RecommenderItem> output = new List<RecommenderItem>();
        int count = Math.Min(restaurantRecommendations.Count, dishRecommendations.Count);
        for (int i = 0; i < count; i++)
        {
            var restRecommendation = restaurantRecommendations[i];
            var dishRecommendation = dishRecommendations[i];
            output.Add(new RecommenderItem()
            {
                Id = restRecommendation.Id,
                Entity = restRecommendation
            });
            output.Add(new RecommenderItem()
            {
                Id = dishRecommendation.Id,
                Entity = dishRecommendation
            });
        }
        int remainingRestaurant = restaurantRecommendations.Count - count;
        int remainingDishes = dishRecommendations.Count - count;
        if (remainingRestaurant > 0)
        {
            for (int i = count; i < remainingRestaurant; i++)
            {
                var restRecommendation = restaurantRecommendations[i];
                output.Add(new RecommenderItem()
                {
                    Id = restRecommendation.Id,
                    Entity = restRecommendation
                });
            }
        }
        else if (remainingDishes > 0)
        {
            for (int i = count; i < remainingDishes; i++)
            {
                var dishRecommendation = dishRecommendations[i];
                output.Add(new RecommenderItem()
                {
                    Id = dishRecommendation.Id,
                    Entity = dishRecommendation
                });
            }
        }
        return output;
    }
