        private void RemovePublicAcl(AmazonS3Client client, string bucket, string key)
        {
            var aclRequest = new GetACLRequest { BucketName = bucket, Key = key };
            var aclResponse = client.GetACL(aclRequest);
            var acl = aclResponse.AccessControlList;
            const string PUBLIC_GRANTEE = "http://acs.amazonaws.com/groups/global/AllUsers";
            if (acl.Grants.Any(x =>
                !string.IsNullOrWhiteSpace(x.Grantee.URI) &&
                x.Grantee.URI.Equals(PUBLIC_GRANTEE)))
            {
                var publicGrant = new S3Grantee();
                publicGrant.URI = PUBLIC_GRANTEE;
                acl.Grants.RemoveAll(x =>
                    !string.IsNullOrWhiteSpace(x.Grantee.URI) &&
                    x.Grantee.URI.Equals(PUBLIC_GRANTEE));
                var aclUpdate = new PutACLRequest();
                aclUpdate.BucketName = bucket;
                aclUpdate.Key = key;
                aclUpdate.AccessControlList = acl;
                var response = client.PutACL(aclUpdate);
            }
