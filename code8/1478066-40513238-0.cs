    interface IDownloadMethod<T> : where T : IPersistable {
       string WebServiceBaseURL { get; set; }
       IEnumerable<T> Download();
       Action<IEnumerable> RepositoryMethod { get; }
    }
