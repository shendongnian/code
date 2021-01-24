            try
            {
                // Initialize the GraphServiceClient.
                GraphServiceClient graphClient = SDKHelper.GetAuthenticatedClient();
                // Get the files and folders in the current user's drive.
                results.Items = await filesService.GetMyFilesAndFolders(graphClient);
            }
            catch (ServiceException se)
            {
                if (se.Error.Message == Resource.Error_AuthChallengeNeeded) return new EmptyResult();
                return RedirectToAction("Index", "Error", new { message = string.Format(Resource.Error_Message, Request.RawUrl, se.Error.Code, se.Error.Message) });
            }
