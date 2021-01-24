    public class BaseClient<T> where T : IGeneric
    {
        public const string apiUrl = "<yoururl>";
        public T client;
        public BaseClient() : base() {
            client = RestService.For<T>(apiUrl);
        }
        public async Task<TResult> ExecFuncAsync<TResult>(Func<TResult> func) 
                                   where TResult : BaseResponse
        {
            TResult rsl = default(TResult);
            T apikey = RestService.For<T>(apiUrl);
            try
            {
                rsl = func.Invoke();
                rsl.Success = true;
            }
            catch (ApiException ax)
            {
				rsl.ErrorMessage = ax.Message;
            }
            catch (Exception ex)
            {
				rsl.ErrorMessage = ex.Message;
            }
            return rsl;
        }
		public async Task<List<TResult>> ExecFuncListAsync<TResult>(Func<List<TResult>> func)
		{
			List<TResult> rsl = default(List<TResult>);
			T apikey = RestService.For<T>(apiUrl);
			try
			{
				rsl = func.Invoke();
			}
			catch (ApiException ax)
			{
			}
			catch (Exception ex)
			{
			}
			return rsl;
		}
	}
