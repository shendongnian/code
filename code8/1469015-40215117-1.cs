    var missingItems = from oldItem in OldItemList
                       join newItem in NewItemList on oldItem.Name equals newItem.Name
                       let missingTags = oldItem.TagList.Where(oldTag => !newItem.TagList.Any(newTag=> oldTag.Id == newTag.Id))
                       where missingTags.Any()
                       select new { Item = newItem, MissingTags = missingTags };
