    interface IRepo { CRUD }
    protected abstract class RepoBase<T> : IRepo 
    {
       // CRUD implementation
    }
    
    interface IPatientRepo : RepoBase<Patient>
    { 
        List<IPatient> GetAllTerminallyIllPatients();
    }
    
    interface IMusicRepo : RepoBase<Music>
    {
        List<ISong> GetAllSongsByArtist (string artist);
    }
