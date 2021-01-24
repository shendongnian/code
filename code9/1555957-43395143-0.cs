    string fileID = "CHANGE_TO_FILE_ID";
    var stream = new System.IO.FileStream(openFile.FileName, System.IO.FileMode.Open)
    var driveFile = new Google.Apis.Drive.v3.Data.File();
    FilesResource.UpdateMediaUpload requestUpdate;
    requestUpdate = service.Files.Update(driveFile, fileID, stream, GetMimeType(openFile.FileName));
    requestUpdate.Fields = "id";
    requestUpdate.Upload();
    var retornoUpdate = requestUpdate.ResponseBody;
    Console.WriteLine("FILE: " + retornoUpdate.Id);
