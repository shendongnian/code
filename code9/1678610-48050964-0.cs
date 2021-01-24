    async Task<byte[]> CreateImage(IFormFile file)
    {
      using (var memoryStream = new MemoryStream())
      {
        await file.CopyToAsync(memoryStream);
        var image = new Image(memoryStream);
        var height = image.Height < 150 ? image.Height : 150;
        image.Resize((int)(image.Width * height / image.Height), height).Save(memoryStream);
        return memoryStream.ToArray();
      }
    }
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> ImageAdd(ImageAddVm vm)
    {
      byte[] image = null;
      if (vm.File != null && vm.File.Length > 0)
         image = await CreateImage(vm.File);
      if (image != null)
      {
        var json = JsonConvert.SerializeObject(new { vm.ObjectId, image });
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var client= new HttpClient();
        await client.PostAsync($"{ApiUrl}/SaveImage", content);
      }
      return RedirectToAction("ReturnAction");
    }
