        // This method creates Task (because it's asynchronous) that can be canceled by token
        public async Task<DriveItem> MyUsefulMethodAsync(string driveId, string itemId, string selectItemParameter,  CancellationToken? cancellationToken = null)
        {
            DriveItem res = default(DriveItem);
            try
            {
                // My useful code, for example:
                res = await Client.Drives[driveId].Items[itemId].Request()
                        .Select(selectItemParameter)
                        .GetAsync(cancellationToken ?? CancellationToken.None);
            }
            catch (OperationCanceledException)
            {
                // We have to propagate out this exception for fine Task state managing.
                throw;
            }
            catch (Exception e)
            {
                // This is workaround for MSGraph bug (https://stackoverflow.com/a/47900445/987850)
                var se = e as ServiceException;
                if (se?.InnerException is OperationCanceledException)
                {
                    throw se.InnerException;
                }
                // My error processing ...
            }
            return res;
        }
