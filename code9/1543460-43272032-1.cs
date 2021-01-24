    public Task Invoke(HttpContext context, BoundedContext dbcontext, ILogger<MyAuthentication> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _dbcontext = dbcontext;
            _context = context;
            StringValues headerValue;
            string encodedJwt = null;
            if (!_context.Request.Headers.TryGetValue("Authorization", out headerValue))
            {
                return _next(_context);
            }
            encodedJwt = headerValue.FirstOrDefault(h => h.Contains(_options.AuthentiacionOptions.AuthenticationScheme));
            if (!string.IsNullOrWhiteSpace(encodedJwt))
            {
                encodedJwt = encodedJwt.Substring((_options.AuthentiacionOptions.AuthenticationScheme.Length + 1));
            }
            if (!string.IsNullOrWhiteSpace(encodedJwt))
            {
                var handler = new JwtSecurityTokenHandler();
                ClaimsPrincipal principal = null;
                SecurityToken validToken = null;
                principal = handler.ValidateToken(encodedJwt, _options.tokenValidationParameters, out validToken);
                _context.User = principal;
                setReportConnectionString();
            }
            
            return _next(_context);
        }               
        private void setReportConnectionString()
        {
            var changeDatabaseCommand = new ChangeDatabaseCommand(_mapper, _context.User);
            CommandService.Process(_dbcontext, new ICommand[] { changeDatabaseCommand });            
        }
