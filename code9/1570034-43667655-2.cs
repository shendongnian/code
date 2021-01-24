    try {
        var list = await client.Files.ListFolderAsync(string.Empty);
        // use list
    } catch (ApiException<Dropbox.Api.Files.ListFolderError> ex) {
        // handle ListFolder-specific error
    } catch (DropboxException ex) {
        // inspect and handle ex as desired
        if (ex is AuthException) {
            // handle AuthException, which can happen on any call
            if (((AuthException)ex).ErrorResponse.IsInvalidAccessToken) {
                // handle invalid access token case
            }
        } else if (ex is HttpException) {
            // handle HttpException, which can happen on any call
        }
    }
