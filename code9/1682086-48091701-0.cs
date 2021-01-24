    var result = fileNames
        .Select(inputString => inputString.Split(new char[] {'_'}))
        .Select(splitStringArray => new
        {
            MainPart = splitStringArray[0],
            SortablePart = splitStringArray[1],
        })
        // now easy to group by MainPart:
        .GroupBy(
            item => item.MainPart,        // make groups with same MainPart, will be the key
            item => item.SortablePart)    // the elements of the group
         // for every group, sort the elements descending and take only the first element
         .Select(group => new
         {
             MainPart = group.Key,
             NewestElement = group                               // take all group elements
                .SortByDescending(groupElement => groupElement)  // sort in descending order
                .First(),
          })
          // I know every group has at least one element, otherwise it wouldn't be a group
          // now form the file name:
          .Select(item => item.MainPart + '_' + item.NewestElement);
