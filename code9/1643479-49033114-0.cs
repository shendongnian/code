    public class ExactQueryParamAttribute : Attribute, IActionConstraint
    {
        private readonly string[] keys;
        public ExactQueryParamAttribute(params string[] keys)
        {
            this.keys = keys;
        }
        public int Order => 0;
        public bool Accept(ActionConstraintContext context)
        {
            var query = context.RouteContext.HttpContext.Request.Query;
            return query.Count == keys.Length && keys.All(key => query.ContainsKey(key));
        }
    }
    [HttpGet]
    [ActionName(nameof(GetByParticipant))]
    [ExactQueryParam("participantId", "participantType", "programName")]
    public async Task<IActionResult> GetByParticipant([FromQuery]string participantId, [FromQuery]string participantType, [FromQuery]string programName)
    {
    }
    [HttpGet]
    [ActionName(nameof(GetByProgram))]
    [ExactQueryParam("programName")]
    public async Task<IActionResult> GetByProgram([FromQuery]string programName)
    {
    }
