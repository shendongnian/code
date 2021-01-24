    [HttpGet]
    [Route("Comments")]
    public IHttpActionResult Comments(string Post_ID)
    {
        var list = db
            .ShalehComments
            .Where(p => p.Shaleh_ID == Post_ID && p.ParentID == 0).ToList()
            .Select(p => new {
                ID = p.ID,
                Comment = p.Comment,
                User = db.Users.FirstOrDefault(x=> x.Id == p.User_ID).FullName,
                UserImage = GetImagePath(db.Users.FirstOrDefault(x => x.Id == p.User_ID).Image),
                InsertDate = p.InsertDate.ToString("dd/MM/yyyy")//and here
        }).ToList();
    
        return Ok(
            new
            {
                result = true,
                data = list
            }
        );
    }
