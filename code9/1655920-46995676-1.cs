        [HttpPost("GetAgencyUser")]
        public IActionResult GetAgencyUser([FromBody]JObject request)
        {
            try
            {
                if (request["id"] == null)
                {
                    return Ok("id is not defined or incorrect JSON format");
                }
                AgencyUsersMethods agencyusers = new AgencyUsersMethods(_configuration);
                var result = agencyusers.GetAgencyUser(request);
                if (result == null)
                {
                    return Ok("User not Found");
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
