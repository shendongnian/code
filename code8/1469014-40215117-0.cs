    var missingItems = from oldItem in OldItemList
                       join newItem in NewItemList on oldItem.Name equals newItem.Name
                       let missingTags = oldItem.TagList.Where(oldTag => !newItem.TagList.Any(newTag=> oldTag.Id == newTag.Id))
                       where missingTags.Any()
                       select string.Foramt("{0} missing tags: {1}." newItem.Name, string.Join(", ", missingTags.Select(tag => tag.Name).ToArray()));
