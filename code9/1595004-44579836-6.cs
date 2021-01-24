    public static async void CopyBlob(Uri sourceBlob, CloudBlockBlob targetBlob, System.Threading.CancellationToken cancellationToken)
    {
       string text  = await targetBlob.StartCopyAsync(
           sourceBlob,
           //Source blob access condition, it will check whether the source is exist. If source doesn't exist, a exeception will throw.
           Access​Condition.GenerateIfExistsCondition(),
           //Target blob access condition, it will check whether the target is exist. If target blob exist, 409 error will occur.
           AccessCondition.GenerateIfNotExistsCondition(),
           null,
           null,
           cancellationToken);
    }
