    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<IActionResult> Like([FromBody]int contentId)
        {
            var userId = await UserId();
            return Json(_content.IsLiked(contentId, true, userId));
        }
