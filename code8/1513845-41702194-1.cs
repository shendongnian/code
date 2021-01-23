    protected RoleManager roleManager = new RoleManager();
        public override string GetCacheKey()
        {
            Sitecore.Sites.SiteContext site = Sitecore.Context.Site;
            if ((Cacheable && ((site == null) || site.CacheHtml)) && !SkipCaching())
            {
                if (VaryByParm)
                {
                    return base.GetCacheKey() + "_#userRole:" + roleManager.GetReadRole(this.GetItem());
                }
                return base.GetCacheKey();
            }
            return string.Empty;
        }
