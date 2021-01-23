    httpClient
        .Setup(x => x.GetAsync(It.Is<Uri>(url => url.AbsoluteUri == APIUrl.AbsoluteUri + <my url>)))
        .Returns(() => Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) {
                Content = new StringContent(Encoding.Default.GetString(fieldBoundary))
            })
        );
