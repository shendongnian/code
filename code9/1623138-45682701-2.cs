    public class FileExistsSpecification : ISpecification
    {
      public async Task<bool> IsSatisfiedByAsync(object o)
      {
        return await _fileStorage.FileExistsAsync(addRequest.FileName);
      }
    }
    public class FileNameSpecification : SynchronousSpecification 
    {
      private static readonly char[] _invalidEndingCharacters = { '.', '/' };
      public override bool IsSatisfiedBy(object o) 
      {
        var request = (AddRequest)o;
        if (string.IsNullOrEmpty(request.FileName))
          return false;
        if (request.FileName.Length > 1024)
          return false;
        if (request.FileName.Contains('\\') || _invalidEndingCharacters.Contains(request.FileName.Last()))
          return false;
        return true;
      }
    }
