    public async Task<IActionResult> UploadFile(IFormFile file){
            byte[] bytes = new byte[file.Length];
            using (var reader = file.OpenReadStream())
            {
                await reader.ReadAsync(bytes, 0, (int)file.Length);
            }
     }
