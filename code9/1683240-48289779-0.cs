    public interface IFileProcessor {
     // add proper constraint for T
     List < T > GetRecords < T > (...);
    }
    
    public class CsvFileProcessor: IFileProcessor {
     List < T > GetRecords < T > (...) {}
    }
    
    public class ExcelFileProcessor: IFileProcessor {
     List < T > GetRecords < T > (...) {}
    }
    
    public class FileService {
     public List < T > ReadFile < T > (HttpPostedFileBase file) {
      // do whatever with `file` here
      IFileProcessor fileProcessor = GetFileProcessor( < fileExt > );
      return fileProcessor.GetRecords < T > (...);
     }
    
     // This is not exact implementation of factory but it serves the same purpose as factory method.
     private static IFileProcessor GetFileProcessor(string fileExt) {
      if ( < csv > ) {
       return ServiceLocator.Current.GetInstance < IFileProcessor > ("csv");
      } 
      else if ( < excel > ) {
       return ServiceLocator.Current.GetInstance < IFileProcessor > ("excel");
      }
     }
    }
