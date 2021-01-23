     public class CategoriesCollection<T> : CKeyedCollection<int, T>
        {
            protected override int GetKeyForItem(T item)
            {
                return (item as Category).Id;
            }
    
            /// <summary>
            /// Method to get the index into the List{} in the base collection for an item that may or may 
            /// not be in the collection. Returns -1 if not found.
            /// </summary>
            protected override int GetItemIndex(T itemToFind)
            {
                Guid keyToFind = GetKeyForItem(itemToFind);
                return BaseList.FindIndex((T existingItem) =>
                                          GetKeyForItem(existingItem).Equals(keyToFind));
            }
        }
