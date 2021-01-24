    // Entities
    public abstract class ThirdParty
    {
    }
    
    public class Student : ThirdParty
    {
    }
    
    public class Worker : ThirdParty
    {
    }
    
    // View models    
    public interface IThirdPartyViewModel<out T>
    {
    }
    
    public abstract class ThirdPartyViewModel<T> : IThirdPartyViewModel<T>
    {
    }
    
    public class StudentVm : ThirdPartyViewModel<Student>
    {
    }
    
    public class WorkerVm : ThirdPartyViewModel<Worker>
    {
    }
    
    public abstract class DocumentViewModel<T> where T : IThirdPartyViewModel<ThirdParty>
    {
    }
    
    public class StudentDocumentVm : DocumentViewModel<StudentVm>
    {
    }
    public class WorkerDocumentVm : DocumentViewModel<WorkerVm>
    {
    }
