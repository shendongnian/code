    var currentFileText = "";
    var contents = await client.Repository.Content.GetAllContentsByRef(owner, repo, targetFilePath, branch);
    var targetFile = contents[0];
    if (targetFile.EncodedContent != null)
    {
        currentFileText = Encoding.UTF8.GetString(Convert.FromBase64String(targetFile.EncodedContent));
    }
    else
    {
        currentFileText = targetFile.Content;
    }
    var newFileText = string.Format("{0}\n{1}", currentFileText, "Added this new line");
    var updateRequest = new UpdateFileRequest("API File update", newFileText, targetFile.Sha, branch);
    var updatefile = await client.Repository.Content.UpdateFile(owner, repo, targetFilePath, updateRequest);
