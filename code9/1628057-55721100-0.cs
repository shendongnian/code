c#
/// <summary>
/// Create a mock for CloudBlobClient
/// </summary>
/// <param name="containerExists"></param>
/// <returns></returns>
private CloudBlobClient GetMock(bool containerExists = true)
{
    var items = new List<IListBlobItem>();
    var client = Substitute.For<CloudBlobClient>(new Uri("http://foo.bar/"), null);
    var container = Substitute.For<CloudBlobContainer>(new Uri("http://foo.bar/"));
    client.GetContainerReference(Arg.Any<string>()).Returns(container);
    container.ExistsAsync(Arg.Any<CancellationToken>()).Returns(Task.FromResult(containerExists));
    container.ListBlobsSegmentedAsync(Arg.Any<string>(), Arg.Any<bool>(), 
                                        Arg.Any<BlobListingDetails>(), 
                                        Arg.Any<int?>(), 
                                        Arg.Any<BlobContinuationToken>(), 
                                        Arg.Any<BlobRequestOptions>(), 
                                        Arg.Any<OperationContext>(), 
                                        Arg.Any<CancellationToken>())
                                        .Returns(ci => new BlobResultSegment(items.ToArray(), null));
    container.GetBlockBlobReference(Arg.Any<string>()).Returns(ci => GetBlockBlobMock(ci.ArgAt<string>(0), items));
    return client;
}
/// <summary>
/// Create a mock for CloudBlockBlob
/// </summary>
/// <param name="name"></param>
/// <param name="listBlobItems"></param>
/// <returns></returns>
private CloudBlockBlob GetBlockBlobMock(string name, List<IListBlobItem> listBlobItems)
{
    var created = DateTimeOffset.Now;
    var bufferStream = new MemoryStream();
    var blob = Substitute.For<CloudBlockBlob>(new Uri("https://foo.blob.core.windows.net/bar/" + name + ".txt"));
    //We can't mock the value the normal way, use reflection to change its value!
    blob.Properties.GetType().GetProperty(nameof(blob.Properties.Created)).SetValue(blob.Properties, created);
    //we cant mock properties! (Dam this wont work)
    blob.UploadFromStreamAsync(Arg.Any<Stream>(),
                                Arg.Any<AccessCondition>(),
                                Arg.Any<BlobRequestOptions>(),
                                Arg.Any<OperationContext>(),
                                Arg.Any<CancellationToken>()).Returns(ci => {
                                    var stream = ci.Arg<Stream>();
                                    stream.CopyTo(bufferStream);
                                    listBlobItems.Add(blob);
                                    return Task.CompletedTask;
                                });
    blob.DownloadToStreamAsync(Arg.Any<Stream>(),
                                Arg.Any<AccessCondition>(),
                                Arg.Any<BlobRequestOptions>(),
                                Arg.Any<OperationContext>(),
                                Arg.Any<CancellationToken>()).Returns(ci =>
                                {
                                    var stream = ci.Arg<Stream>();
                                    bufferStream.Position = 0;
                                    bufferStream.CopyTo(stream);
                                    stream.Position = 0;
                                    return Task.CompletedTask;
                                });
    return blob;
}
I'm not 100% sure its 100% accurate but it allows me to run some unit tests!
