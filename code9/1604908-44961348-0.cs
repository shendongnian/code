    string leftToRight = ((char)0x200E).ToString();
    // using string.Format
    return string.Format("{0}{1}{2}{3}",
                IdWithSubType,
                leftToRight,
    
                ExtraInfo.Any(info => info.InfoType == UniExtraInfoType.Alias)
                ? string.Format(" ({0})", string.Join(",", ExtraInfo.First(info => info.InfoType == UniExtraInfoType.Alias).Info))
                : "",
    
                Context != null
                ? string.Format(" ({0})", Context.IdWithSubType)
                : "");,
    // alternative: using string.Join
    return string.Join(leftToRight, IdWithSubType,
                ExtraInfo.Any(info => info.InfoType == UniExtraInfoType.Alias)
                ? string.Format(" ({0})", string.Join(",", ExtraInfo.First(info => info.InfoType == UniExtraInfoType.Alias).Info))
                : "",
                Context != null
                ? string.Format(" ({0})", Context.IdWithSubType)
                : "");,
