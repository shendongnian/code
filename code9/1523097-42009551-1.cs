    public class Importer
        {
            private readonly IRepository<FileTable> _fileRepository;
            private readonly IRepository<ImportLog> _importRepo;
    
            private bool IsValid(string line)
            {
                //Refer to a bunch of database tables and return true or false. Below is just a random code that demonstrates this
                //if (_fileRepository.Query().Count(t => t.Prop1 == line[2]) > 0 &&
                //    _importRepo.Query().First(t => t.Prop2 == line[3]).Prop3 != null
                    
                return false;
            }
    
            public Importer(IRepository<FileTable> fileRepository, IRepository<ImportLog> importRepo, ILogParser logFile)
            {
                //use DI...
                //var dbContext = new FusionContext();
                //fileRepository = new Repository<FileTable>(dbContext);
                //importRepo = new Repository<ImportLog>(dbContext);
    
                _fileRepository = fileRepository;
                _importRepo = importRepo;
            }
            public void Process(string fileName)
            {
                var log = new ImportLog();
    
                //I would use and interface to get logfile
                foreach (var line in _logParser.GetLinesFrom(fileName) { //GetNextLine reads the file and yield returns lines
                    if (IsValid(line))
                    { //IsValid refers to a bunch of tables and returns true/false
                        log.Imported++;
                        FileTable fileTable = new  FileTable();
                        fileTable.Line = line;
                        _fileRepository.Add(fileTable, true);
                    }
                    else { log.Rejected++; }
                }
    
                _importRepo.Add(log, true);
    
                _importRepo.SaveChanges();
    
                //because importRepo and fileRepo are using same dbContext instance, they will be saved in one transaction
            }
        }
