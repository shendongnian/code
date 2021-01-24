    // Form >> Tab Control >> 1st Tab >> 1st Child.
    // This assumes AddTab<Cat1Content>() was called.
    var firstContent = (Cat1Content)tabContents[0];
    // Content >> PrimaryPanel; Enumerates over nested controls.
    foreach (var child in firstContent.PrimaryPanel.Controls) {
        // ...
    }
    // Content >> Tab Control; Enumerates over nested tabs. 
    foreach (var child in firstContent.TabManager.Controls) {
        // This is safe, TabControl throws an exception if you try to add anything that isn't a TabPage.
        var tab = (TabPage)child;
        // ...
    }
