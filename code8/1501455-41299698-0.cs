     public IList<WebSyncSummaryView> GetWebSyncSummary()
        {
            IList<WebSyncSummaryView> _WebSyncSummaryView = null;
            IList<WebSyncSummaryEntity> _WebSyncSummaryEntity = _WebSyncCoreObject.GetWebSyncSummary();
          
            if (_WebSyncSummaryEntity != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMissingTypeMaps = true; //............... missing this
                    cfg.CreateMap<WebSyncSummaryEntity, WebSyncSummaryView>();
                });
                IMapper mapper = config.CreateMapper();
                _WebSyncSummaryView = mapper.Map<IList<WebSyncSummaryEntity>, IList<WebSyncSummaryView>>(_WebSyncSummaryEntity);
            }
