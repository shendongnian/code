class AttachmentEnumerable : IEnumerable<Attachment>
{
    private AttachmentCollection underlyingCollection;
    public AttachmentEnumerable(AttachmentCollection coll)
    { underlyingCollection = coll; }
    public IEnumerator<Attachment> GetEnumerator()
    {
        foreach (Attachment item in underlyingCollection)
        {
            yield return item;
        }
    }
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
Also the `Attachment` object contains only a URL that you have to download later on.
