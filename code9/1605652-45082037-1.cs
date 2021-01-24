    namespace client.Models
    {
    public class FileListModel
    {
    public FileListModel(IEnumerable<IListBlobItem> list)
    {
    if (list != null)
    {
    Files = new List<FileInfo>();
    foreach (var item in list)
    {
    FileInfo info = FileInfo.CreateFromIListBlobItem(item);
    if (info != null)
    {
    Files.Add(info);
    }
    }
    }
    }
    public List<FileInfo> Files { get; set; }
    }
    public class FileInfo
    {
    public string FileName { get; set; }
    public string URL { get; set; }
    public long Size { get; set; }
    
    public static FileInfo CreateFromIListBlobItem(IListBlobItem item)
    {
    if (item is CloudBlockBlob)
    {
    var blob = (CloudBlockBlob)item;
    return new FileInfo { FileName = blob.Name,
    URL = blob.Uri.ToString(),
    Size = blob.Properties.Length };
    }
    return null;
    }
    }
    }
