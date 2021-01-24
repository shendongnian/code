    public sealed class PrinterInfo
    {
        public string IdName { get; }
        public string DisplayName { get; }
        public Bitmap Image { get; }
        private PrinterInfo(string idName, string displayName, Bitmap image)
        {
            IdName = idName;
            DisplayName = displayName;
            Image = image;
        }
        public static IReadOnlyList<PrinterInfo> GetInstalledPrinterNamesAndImages(Size imageSize)
        {
            var r = new List<PrinterInfo>();
            using (var folderIdList = CreateDevicesAndPrintersIDL())
            {
                var folder = GetShellFolder(folderIdList);
                var enumerator = folder.EnumObjects(IntPtr.Zero, SHCONTF.NONFOLDERS);
                for (;;)
                {
                    // If you request more than are left, actualCount is 0, so we'll do one at a time.
                    var next = enumerator.Next(1, out var relativeIdList, out var actualCount);
                    next.ThrowIfError();
                    if (next == HResult.False || actualCount != 1) break; // printerChild is junk
                    using (relativeIdList)
                    using (var absoluteIdList = ILCombine(folderIdList, relativeIdList))
                    {
                        var shellItem = GetShellItem(absoluteIdList);
                        var idName = GetPrinterFriendlyNameIfPrinter(shellItem);
                        if (idName != null)
                            r.Add(new PrinterInfo(idName, GetDisplayName(shellItem), GetImage(shellItem, imageSize)));
                    }
                }
            }
            return r;
        }
        private static ItemIdListSafeHandle CreateDevicesAndPrintersIDL()
        {
            SHGetKnownFolderIDList(FOLDERID.ControlPanelFolder, KF_FLAG.DEFAULT, IntPtr.Zero, out var controlPanelIdList).ThrowIfError();
            using (controlPanelIdList)
            {
                GetShellFolder(controlPanelIdList).ParseDisplayName(IntPtr.Zero, null, "::{A8A91A66-3A7D-4424-8D24-04E180695C7A}", IntPtr.Zero, out var childDevicesAndPriversIdList, IntPtr.Zero);
                using (childDevicesAndPriversIdList)
                    return ILCombine(controlPanelIdList, childDevicesAndPriversIdList);
            }
        }
        private static string GetPrinterFriendlyNameIfPrinter(IShellItem2 shellItem)
        {
            // Devices_PrimaryCategory returns "Printers" for printers and faxes on Windows 10 but "Printers and faxes" on Windows 7.
            using (var categoryIds = new PropVariantSafeHandle())
            {
                shellItem.GetProperty(PKEY.Devices_CategoryIds, categoryIds).ThrowIfError();
                if (!categoryIds.ToStringVector().Any(id => id.StartsWith("PrintFax", StringComparison.OrdinalIgnoreCase)))
                    return null;
            }
            // The canonical or "friendly name" needed to match the devmode
            // https://blogs.msdn.microsoft.com/asklar/2009/10/21/getting-the-printer-friendly-name-from-the-device-center-shell-folder/
            // PKEY_Devices_InterfacePaths doesn't seem to ever be found, but PKEY_Devices_FriendlyName works so...
            shellItem.GetString(PKEY.Devices_FriendlyName, out var friendlyName).ThrowIfError();
            return friendlyName.ReadAndFree();
        }
        private static string GetDisplayName(IShellItem2 shellItem)
        {
            return shellItem.GetDisplayName(SIGDN.NORMALDISPLAY).ReadAndFree();
        }
        private static Bitmap GetImage(IShellItem2 shellItem, Size imageSize)
        {
            return ((IShellItemImageFactory)shellItem).GetImage(new POINT(imageSize.Width, imageSize.Height), SIIGBF.SIIGBF_BIGGERSIZEOK)
                .CopyAndFree(); // Bitmap.FromHbitmap is useless with alpha, so make a copy
        }
        private static IShellFolder GetShellFolder(ItemIdListSafeHandle itemIdList)
        {
            SHBindToObject(IntPtr.Zero, itemIdList, null, typeof(IShellFolder).GUID, out var objShellFolder).ThrowIfError();
            return (IShellFolder)objShellFolder;
        }
        private static IShellItem2 GetShellItem(ItemIdListSafeHandle itemIdList)
        {
            SHCreateItemFromIDList(itemIdList, typeof(IShellItem2).GUID, out var objShellItem).ThrowIfError();
            return (IShellItem2)objShellItem;
        }
    }
    
