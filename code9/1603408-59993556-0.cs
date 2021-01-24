    AttachmentItem attachmentItem= new AttachmentItem
                { 
                    Name = [Name],
                    AttachmentType = AttachmentType.File,
    Size = [Size]
                };
    
    var session = graphClient.Users[USEREMAIL].Messages[MESSAGEID].Attachments.CreateUploadSession(attachmentItem).Request().PostAsync().Result;
                var stream = new MemoryStream(BYTEARRAY);
                var maxSizeChunk = DEFAULT_CHUNK_SIZE;
                var provider = new ChunkedUploadProvider(session, graphClient, stream, maxSizeChunk);
                var chunkRequests = provider.GetUploadChunkRequests();
