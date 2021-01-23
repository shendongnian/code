           CloudAppendBlob appendBlob = container.GetAppendBlobReference("myAppendBlob");
            appendBlob.FetchAttributes();
            var etag = appendBlob.Properties.ETag;
            try
            {
                appendBlob.DownloadText(Encoding.UTF8, AccessCondition.GenerateIfMatchCondition(etag));
            }
            catch (Exception)
            {
                appendBlob.FetchAttributes();
                var updateEtag = appendBlob.Properties.ETag;
                Console.WriteLine($"Original:{etag},Updated:{updateEtag}");
                //To Do list
                //appendBlob.DownloadText(Encoding.UTF8, AccessCondition.GenerateIfMatchCondition(updateEtag));
            }
