    private static string Filename(string directoryName){
        return string.Format("**{0}/{1}.entry.log.xml**",
                                directoryName,
                                DateTime.Today.ToString("yyyy_MM_dd",
                                DateTimeFormatInfo.InvariantInfo));
    }
