     public async Task ToggleLicesneIsValid(string UID, int licenseId)
        {
            var filter = Builders<Customer>.Filter.ElemMatch(x => x.licence_holders, i => i.UID == UID);
            var customer = DMSLicenseCollection.Find(filter).FirstOrDefault();
            var item = customer.licence_holders.FirstOrDefault(x => x.UID == UID).licenses.FirstOrDefault(y => y.license_id == licenseId);
            item.is_valid = !item.is_valid;
            await DMSLicenseCollection.ReplaceOneAsync(o => o.mongoId == customer.mongoId, customer);
        }
