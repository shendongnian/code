	if (!file.Exists) {
		response.StatusCode = HttpStatusCode.NotFound;
		response.ReasonPhrase = "Deleted";
	} else {
		var range = Request.Headers.Range?.Ranges?.FirstOrDefault();
		if (range == null) {
			using (var stream = new MemoryStream()) {
				using (var video = file.OpenRead()) await video.CopyToAsync(stream);
				response.Content = new ByteArrayContent(stream.ToArray());
			}
			response.Content.Headers.ContentType = new MediaTypeHeaderValue("video/mp4");
			response.Content.Headers.ContentLength = file.Length;
		} else {
			var stream = new MemoryStream();
			using (var video = file.OpenRead()) await video.CopyToAsync(stream);
			response.Content = new ByteRangeStreamContent(
				stream,
				new RangeHeaderValue(range.From, range.To),
				new MediaTypeHeaderValue("video/mp4")
			);
			//	response.Content.Headers.ContentLength = file.Length;
			// this is what makes iOS work
			response.Content.Headers.ContentLength = (range.To.HasValue ? range.To.Value + 1 : file.Length) - (range.From ?? 0);
		}
		response.StatusCode = HttpStatusCode.OK;
	}
