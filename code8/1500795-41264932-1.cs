    for (int i = 0; i < sLines.Count(); i++)
    {
        // `i` is representing current "index" of processed "word"
        // we can use this to find last "valid" element
        // string notEmpty = sLines.Take(i).LastOrDefault(word => !string.IsNullOrEmpty(word));
        // but since you want to assign this to `Value` and there can be not empty string at `i` index
        // we can make it in one line :
        Value = string.IsNullOrEmpty(sLines[i]) ? sLines.Take(i).LastOrDefault(word => !string.IsNullOrEmpty(word)) : sLines[i].SValue;
        // instead of your previous logic :
        //if (sLines[i].SValue == "")
        //{
        //    LastSValue = "***";
        //    Value = LastSValue;
        //}
        //else
        //{
        //    Value = (sLines[i].SValue);
        //}
     }
