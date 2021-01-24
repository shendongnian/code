        public async Task<IHttpActionResult> PostAds(Ads ads, AdsCategory adsCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Ads.AdsCategories.Add(adsCategory);
            AdsCategory.Ads.Add(ads)
            int result = await db.SaveChangesAsync();
            if (result > 0)
            {
                return Ok(result);
            }
            return InternalServerError();
        }
