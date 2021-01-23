          while (bytesRemaining > 0)
          {
              long transferSize = bytesRemaining > partSize ? partSize : bytesRemaining;
              long partIndex = fileLength - bytesRemaining;
              bytesRemaining -= transferSize;
              bool isLastPart = bytesRemaining == 0;
              partNumber++;
              UploadPartResponse resp =
                  cryptoClient.UploadPart(
                      new UploadPartRequest()
                      {
                          BucketName   = bucketName,
                          Key          = keyName,
                          FilePath     = uploadSourcePath,
                          FilePosition = partIndex,
                          PartSize     = isLastPart ? 0 : transferSize,
                          PartNumber   = partNumber,
                          UploadId     = uploadId,
                          IsLastPart   = isLastPart 
                      });
              partETags.Add( new PartETag( partNumber, resp.ETag ));
          }
