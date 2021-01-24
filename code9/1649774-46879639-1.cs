    [HttpPost]
        public async Task<IActionResult> DownloadFiles(string container, int projectId, int? profileId)
        {
            MemoryStream ms = null;
            _ctx.Add(new ProjectDownload() { ProfileId = profileId, ProjectId = projectId });
            await _ctx.SaveChangesAsync();
            using (ms = (MemoryStream)await _blobs.GetBlobsAsZipAsync(container))
            {
                return File(ms.ToArray(), "application/zip", "download.zip");             
            }
        }
