            private readonly IServiceProvider _provider;
    
            public FacebookBotController(ApplicationDbContext context, IServiceProvider provider)
            {
                _provider = provider;
    
    }
    
      [HttpPost]
            public ActionResult WebHook([FromBody] BotRequest data)
            {
    
                if (data == null || data?.entry?.Count == 0)
                {
                    return new StatusCodeResult(StatusCodes.Status204NoContent);
                }
    
       
                try
                {
     
                    var task = Task.Factory.StartNew(async () =>
                    {
    
                        using (IServiceScope scope = _provider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                        {
                            ApplicationDbContext _contx = _provider.GetService<ApplicationDbContext>();
    
                            ContextWatsonFB contextWatsonFB = await _contx.ContextWatsonFB.Where(m => m.SenderId == senderId).FirstOrDefaultAsync();
    
                            if (contextWatsonFB == null)
                            {
                                context = null;
                            }
                            else
                            {
                                context = JsonConvert.DeserializeObject<Context>(contextWatsonFB.Context);
                            }
    
                        }
    
    }
    }
