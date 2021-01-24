    interface IRepo { CRUD }
    protected abstract class RepoBase<T> : IRepo 
    {
       // CRUD implementation
    }
    
    public class PatientRepo : RepoBase<Patient>
    { 
        List<IPatient> GetAllTerminallyIllPatients();
    }
    
    public class MusicRepo : RepoBase<Music>
    {
        List<ISong> GetAllSongsByArtist (string artist);
    }
