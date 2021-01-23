        [HttpGet]
        [Route("api/v1/codes/uidRequest/{uidRequestKey}")]
        [ResponseType(typeof(UIDRequestUIDsModel))]
        public async Task<IHttpActionResult> ViewUIDs(string uidRequestKey)
        {
            var uidRequestKeyGuid = uidRequestKey.ToNullableGuid();
            if (uidRequestKeyGuid == null)
            {
                return BadRequest($"{uidRequestKey} is not a valid guid");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var validatedResult = await _uidRequestApiService.GetUIDRequestUIDsAsync(uidRequestKeyGuid.Value, CurrentUserIdentity);
            return ParseValidatedResult(validatedResult);
        }
