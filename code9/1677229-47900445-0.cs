        internal async Task<HttpResponseMessage> SendRequestAsync(
            HttpRequestMessage request,
            HttpCompletionOption completionOption,
            CancellationToken cancellationToken)
        {
            try
            {
                return await this.httpClient.SendAsync(request, completionOption, cancellationToken).ConfigureAwait(false);
            }
            catch (TaskCanceledException exception)
            {
                throw new ServiceException(
                        new Error
                        {
                            Code = ErrorConstants.Codes.Timeout,
                            Message = ErrorConstants.Messages.RequestTimedOut,
                        },
                        exception);
            }
            catch (Exception exception)
            {
                throw new ServiceException(
                        new Error
                        {
                            Code = ErrorConstants.Codes.GeneralException,
                            Message = ErrorConstants.Messages.UnexpectedExceptionOnSend,
                        },
                        exception);
            }
        }
