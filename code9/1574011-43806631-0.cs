    // Creates an instance of the Tree provider
    TreeProvider tree = new TreeProvider(MembershipContext.AuthenticatedUser);
    
    // Gets the published version of pages stored under the "/Articles/" path
    // The pages are retrieved from the Dancing Goat site and in the "en-us" culture
    var pages = tree.SelectNodes()
        .ClassNames("custom.CustomPressRelease")
        .Path("/Articles/", PathTypeEnum.Children)
        .WhereLike("DocumentName", "Coffee%")
        .Columns("NodeAliasPath", "DateIssued", "ContentTitle", "TeaserText", "GeoCoverage")
        .OnSite("DancingGoat")
        .Culture("en-us");
