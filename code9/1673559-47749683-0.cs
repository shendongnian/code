    var CategoryId = ...
    string categoryName = "|" + CategoryId + "|";
    var result = db.Tag_Group
       // I want only those tagGroupElements that have at least one Tag
       // in sequence Tags that matches both conditions:
       .Where(tagGroupElement => tagGroupEleent.Tags
                 // the tagGroupElement should have a matching CategoryName
           .Where(tag => tag.CategoryName == categoryName)
                 // and the tagGroupElement should have at least one item
                 // in Tag_List with ItemOnStock > 0
              && tag.Tag_List
                  .Where(tagListElement => tagListElement.ItemOnStock > 0)
                  .Any())
           .Any());
