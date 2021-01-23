            using (var request = this.GetHttpRequestMessage())
            {
                //await this.Client.AuthenticationProvider.AuthenticateRequestAsync(request).ConfigureAwait(false);
                request.Content = new StreamContent(stream);
                request.Content.Headers.ContentRange =
                    new ContentRangeHeaderValue(this.RangeBegin, this.RangeEnd, this.TotalSessionLength);
                request.Content.Headers.ContentLength = this.RangeLength;
                return await this.Client.HttpProvider.SendAsync(request, completionOption, cancellationToken).ConfigureAwait(false);
            }
