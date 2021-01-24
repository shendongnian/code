    public class TaskFactory<T> {
		public TaskCompletionSource<T> Task { get; private set; }
		public Task<T> GetTask() {
			Task = new TaskCompletionSource<T>();
			return Task.Task;
		}
	}
