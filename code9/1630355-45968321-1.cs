    public static SiteSettingEntity GetSettings<T>(string siteId, Expression<Func<SiteSettingEntity, object>> properties)
        {
            string query = $"SELECT TOP 1 {DbTool.GetSqlFields(properties)} FROM {SiteSettingEntity.TABLE_NAME} (NOLOCK) WHERE Sites.SiteID = @SiteID";
    
            var parameters = new Dictionary<string, object>
            {
                {"SiteID", siteId},
            };
    
            var _data = DbTool.SqlExec<SiteSettingEntity>(PowerDetailContext.GetConnectionString(siteId), CommandType.Text, query, parameters);
    
            return _data != null ? _data.FirstOrDefault() : default(SiteSettingEntity);
        }
