Collection collection = new Collection(1, 2, 3);
Item item = collection.Get(1);
// c is now available for collection, as there are no longer any P/invokes nor references to it
item.GetValue(); // Can possibly throw AccessViolationException if collection has been collected
                 // based on how it cleans up its items.
To prevent this from happening, you must prevent `collection` from being finalized/disposed until *after* all of them `item`s are done being used. This can be done in a few ways:
 - Utilize `GC.KeepAlive()` at the end of all of the uses of `item`s. E.g.
item.GetValue();
GC.KeepAlive(collection);
 - Utilize the `IDisposable` pattern to ensure deterministic disposal of the parent object. E.g.
using(Collection collection = new Collection(1, 2, 3))
{
    Item item = collection.Get(1);
    item.GetValue();
}
So manual disposal or using the `IDisposable` pattern is not *necessary* per se, but it can be useful to make sure that your use of the unmanaged objects is safe, consistent, and clear.
