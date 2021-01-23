    public interface ILoader {
        Task LoadAsync(List<int> data);
    }
    
    public class SystemUnderTest {
        private readonly ILoader loader;
        public SystemUnderTest(ILoader loader) {
            this.loader = loader;
        }
    
        public async Task InvokeAsync(int count) {
            var data = Enumerable.Range(1,count).ToList();
            await loader.LoadAsync(data);
        }
    
    }
