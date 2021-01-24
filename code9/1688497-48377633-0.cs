    // Microsoft.Bot.Builder.Luis.Extensions
    public static bool TryFindEntity(this LuisResult result, string type, out EntityRecommendation entity)
    {
        IList<EntityRecommendation> expr_14 = result.Entities;
        entity = ((expr_14 != null) ? expr_14.FirstOrDefault((EntityRecommendation e) => e.Type == type) : null);
        return entity != null;
    }
