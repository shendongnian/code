        [HttpGet("[Action]", Name = "GetSomething")]
        [Route("[Action]")]
        public JsonResult something()
        {
            try
            {
                var loggedInUser = HttpContext.User;
                var claym = loggedInUser.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name);
                if (claym != null)
                {
                    return new JsonResult(claym.Value);
                    // returns "tanush"
                }
                else
                {
                    return new JsonResult("");
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }
