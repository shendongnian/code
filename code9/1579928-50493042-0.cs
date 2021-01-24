    public static V GenericLuisEntityResolution<V>(EntityRecommendation entity)
            {
                dynamic result = null;
    
                if (entity.Resolution == null)
                {
                    result = entity.Entity;
                } else
                {
                    dynamic value = entity.Resolution.FirstOrDefault().Value;
                    result = value[0];
                }
    
                return result;
            }
     Dictionary<string,dynamic> date = GenericLuisEntityResolution<dynamic>(yourdata...);
      date ["start"].....
