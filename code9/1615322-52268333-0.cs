        [HttpGet("GetAll")]
        public IEnumerable<string> GetAll()
        {
            var user = HttpContext.User;
            var claims = ((System.Security.Claims.ClaimsIdentity)user.Identity).Claims;
            var items = claims.ToList();
            var jsonstr = items.Last().Value;
            FirebaseIdentity fb = (FirebaseIdentity)JsonConvert.DeserializeObject(jsonstr, typeof(FirebaseIdentity));
            //**** get the user email address here ***
            var useremail = fb.identities.email[0];
            return new string[] { "value1", "value2" };
        }
