    public static WhateverYourDataTypeIs GetParent(int parentCategoryId)
            var parentData = testData.Where(x => x.CategoryId == parentCategoryId).FirstOrDefault();
            if(string.IsNullOrEmpty(parentData.Keywords))
            {
                return GetParent(parentData.ParentCategoryId);
            }
            return parentData;
    }
