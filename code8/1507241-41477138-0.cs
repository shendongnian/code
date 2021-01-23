    void Delete(Resource resource, String filename) {
        try {
            this.RemoveImageFromDatabase(resource);
            }
        catch {
            }
        try {
            _blobStorage.DeleteBlob(filename);
            }
        catch {
            }
        }
