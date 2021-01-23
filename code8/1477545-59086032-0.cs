    public async Task<IActionResult> GetBody()
    {
          string body="";
          using (StreamReader stream = new StreamReader(Request.Body))
          {
               body = await stream.ReadToEndAsync();
          }
        return Json(body);
    }
