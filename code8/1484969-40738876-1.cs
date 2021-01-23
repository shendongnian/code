    using System.Collections.Generic;
    using System.Web.Http;
    using AMMS.Logger.Interfaces;
    using AMMS.Service.Interfaces;
    using AMMS.Service.Models;
    
    namespace AMMS.Api.Controllers
    {
        public class ModuleController: BaseController
        {
            private readonly IModuleService _moduleService;
    
            public ModuleController(IModuleService moduleService, ILoggerService loggerService) : base(loggerService)
            {
                _moduleService = moduleService;
            }
    
            public List<AmmsModule> Get(string userId)
            {
                return _moduleService.GetModules(userId);
            } 
        }
    }
