    public interface IService {
        Task<Result> method(string input);
    }
    public class Result {
        public bool Succeeded { get; set; }
    }
