    public ValuesController : Controller
    {
        //Omitted irrelevant to issue
        [HttpGet]
        [AllowAnonymous]
        public async Task<Message[]> GetList([FromQuery] IFilterResolver<Message> options)
        {
            return await this._service.GetList(options);
        }
    }
