csharp
using System.IO;
using Microsoft.AspNetCore.Mvc;
csharp
[HttpGet("{id}")]
public async Task<FileStreamResult> Download(int id)
{
    var path = "<Get the file path using the ID>";
    var stream = File.OpenRead(path);
    return new FileStreamResult(stream, "application/octet-stream");
}
Note:
Be sure to use `FileStreamResult` from `Microsoft.AspNetCore.Mvc` and **not** from `System.Web.Mvc`.
