    public class FileBaseMap: ClassMap<FileBase> {
        CompositeId()
           .KeyProperty(x => x.IdFile)
           .KeyProperty(x => x.IdRow);
     
        HasMany(x => x.Errors).AsBag().KeyColumns.Add("IdFile", "IdRow");
        // One table per concrete class.
        UseUnionSubclassForInheritanceMapping();
    }
    public class File1Map: SubclassMap<File1> {
        // Other properties mapping
    }
    public class File2Map: SubclassMap<File2> {
        // Other properties mapping
    }
    public abstract class FileBase {
        public int IdFile {get; set;}
        public int IdRow {get; set;}
        public List<Error> Errors {get; set;}
    }
    public class File1 : FileBase {
        // ...other properties different from File2
    }
    public class File2 : FileBase {
        // ...other properties different from File1
    }
