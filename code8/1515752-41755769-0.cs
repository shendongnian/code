    adList = adList.Where(ad => 
               filter.ContentRatings.IsG && ad.IsG
            || filter.ContentRatings.IsPG && ad.IsPG
            || filter.ContentRatings.IsPG13 && ad.IsPG13
            || filter.ContentRatings.IsR && ad.IsR);
