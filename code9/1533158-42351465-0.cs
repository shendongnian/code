    var arr1 = parsedMerchantData.OrderBy(x => x.x.ItemID).ToArray();
    var arr2 = HitCountItemID.OrderBy(x => x.ItemID).ToArray();
    var i, j = 0;
    while(i + j < arr1.Length() + arr2.Length()) // or similar condition
    {
        if (arr1[i].ItemID < arr2[j].ItemID) {
            if (i < arr1.Length() - 1) {
                i++;
            }
            continue;
        }
        if (arr1[i].ItemID > arr2[j].ItemID) {
            if (j < arr2.Length() - 1) {
                j++;
            }
            continue;
        }
        if (arr1[i].ItemID == arr2[j].ItemID) {
            DO_WHAT_YOU_WANTED();
            // if (arr2[j].HitCount != -1) and so on..
        }
        // Make sure you do not let i and j grow higher then lengths of arrays
    }
