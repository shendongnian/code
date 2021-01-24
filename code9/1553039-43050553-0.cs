            var sasToken = blob.GetSharedAccessSignature(new SharedAccessBlobPolicy()
            {
                Permissions = SharedAccessBlobPermissions.Read,
                SharedAccessExpiryTime = DateTime.UtcNow.AddHours(1),
            }, new SharedAccessBlobHeaders()
            {
                ContentDisposition = "attachment;filename=" + blob.Name
            });
            var blobUrl = string.Format("{0}{1}", blob.Uri.AbsoluteUri, sasToken);
            return Redirect(blobUrl);
 
