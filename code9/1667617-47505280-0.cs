	await Task.Run(() =>
	{
		var faceServiceClient = new FaceServiceRestClient(faceEndpoint, faceAPIKey);
		using (var imageFileStream = camera.SingleImageStream)
		{
			var faceAttributes = new FaceServiceClientFaceAttributeType[] { FaceServiceClientFaceAttributeType.Gender, FaceServiceClientFaceAttributeType.Age, FaceServiceClientFaceAttributeType.Smile, FaceServiceClientFaceAttributeType.Glasses, FaceServiceClientFaceAttributeType.FacialHair };
			var faces = faceServiceClient.Detect(imageFileStream, true, false, faceAttributes);
			foreach (var face in faces)
			{
				Log.Debug(TAG, $"{face.FaceRectangle.Left}:{face.FaceRectangle.Top}:{face.FaceRectangle.Width}:{face.FaceRectangle.Height}");
				DrawFaceRect(face.FaceRectangle);
				TagPhoto(face.FaceAttributes);
			}
		}
	});
