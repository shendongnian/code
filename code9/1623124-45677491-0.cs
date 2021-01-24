    public class FileExistsSpecification : CompositeSpecification
    {
        public override bool IsSatisfiedBy(object o)
        {
            var addRequest = (AddRequest)o
            Task<bool> fileExistsResult = _fileStorage.FileExistsAsync(addRequest.FileName);
            fileExistsResult.Wait();
            return fileExistsResult.Result;
        }
    }
