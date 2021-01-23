      var missingItems = from oldItem in OldItemList
                   join newItem in NewItemList on oldItem.Name equals newItem.Name
                   where oldItem.TagList.Any(tagList1 => !newItem.TagList.Any(tagList2 => tagList1.Id == tagList2.Id))
                   select new string{ oldItem.Name + " missing tag " + 
                   String.Join(",",oldItem.TagList.Any(tagList1 => !newItem.TagList.Any(tagList2 => tagList1.Id == tagList2.Id)).Select(taglist=>taglist.Name))};
