        /// <summary>
        /// Main feature. Return actual path for file from uri. 
        /// </summary>
        /// <param name="uri">File's uri</param>
        /// <param name="context">Current context</param>
        /// <returns>Actual path</returns>
        private static string GetActualPathForFile(global::Android.Net.Uri uri, Context context)
        {
            bool isKitKat = Build.VERSION.SdkInt >= BuildVersionCodes.Kitkat;
            if (isKitKat && DocumentsContract.IsDocumentUri(context, uri))
            {
                // ExternalStorageProvider
                if (IsExternalStorageDocument(uri))
                {
                    string docId = DocumentsContract.GetDocumentId(uri);
                    char[] chars = { ':' };
                    string[] split = docId.Split(chars);
                    string type = split[0];
                    if ("primary".Equals(type, StringComparison.OrdinalIgnoreCase))
                        return global::Android.OS.Environment.ExternalStorageDirectory + "/" + split[1];
                }
                // Google Drive
                else if (IsDiskContentUri(uri))
                    return GetDriveFileAbsolutePath(context, uri);
                // DownloadsProvider
                else if (IsDownloadsDocument(uri))
                {
                    try
                    {
                        string id = DocumentsContract.GetDocumentId(uri);
                        if (!TextUtils.IsEmpty(id))
                        {
                            if (id.StartsWith("raw:"))
                                return id.Replace("raw:", "");
                            string[] contentUriPrefixesToTry = new string[]{
                                    "content://downloads/public_downloads",
                                    "content://downloads/my_downloads",
                                    "content://downloads/all_downloads"
                            };
                            string path = null;
                            foreach (string contentUriPrefix in contentUriPrefixesToTry)
                            {
                                global::Android.Net.Uri contentUri = ContentUris.WithAppendedId(
                                        global::Android.Net.Uri.Parse(contentUriPrefix), long.Parse(id));
                                path = GetDataColumn(context, contentUri, null, null);
                                if (!string.IsNullOrEmpty(path))
                                    return path;
                            }
                            // path could not be retrieved using ContentResolver, therefore copy file to accessible cache using streams
                            string fileName = GetFileName(context, uri);
                            Java.IO.File cacheDir = GetDocumentCacheDir(context);
                            Java.IO.File file = GenerateFileName(fileName, cacheDir);
                            if (file != null)
                            {
                                path = file.AbsolutePath;
                                SaveFileFromUri(context, uri, path);
                            }
                            // last try
                            if (string.IsNullOrEmpty(path))
                                return global::Android.OS.Environment.ExternalStorageDirectory.ToString() + "/Download/" + GetFileName(context, uri);
                            return path;
                        }
                    }
                    catch
                    {
                        return global::Android.OS.Environment.ExternalStorageDirectory.ToString() + "/Download/" + GetFileName(context, uri);
                    }
                }
                // MediaProvider
                else if (IsMediaDocument(uri))
                {
                    string docId = DocumentsContract.GetDocumentId(uri);
                    char[] chars = { ':' };
                    string[] split = docId.Split(chars);
                    string type = split[0];
                    global::Android.Net.Uri contentUri = null;
                    if ("image".Equals(type))
                        contentUri = MediaStore.Images.Media.ExternalContentUri;
                    else if ("video".Equals(type))
                        contentUri = MediaStore.Video.Media.ExternalContentUri;
                    else if ("audio".Equals(type))
                        contentUri = MediaStore.Audio.Media.ExternalContentUri;
                    string selection = "_id=?";
                    string[] selectionArgs = new string[] { split[1] };
                    return GetDataColumn(context, contentUri, selection, selectionArgs);
                }
            }
            // MediaStore (and general)
            else if ("content".Equals(uri.Scheme, StringComparison.OrdinalIgnoreCase))
            {
                // Return the remote address
                if (IsGooglePhotosUri(uri))
                    return uri.LastPathSegment;
                // Google Disk document .legacy
                if (IsDiskLegacyContentUri(uri))
                    return GetDriveFileAbsolutePath(context, uri);
                return GetDataColumn(context, uri, null, null);
            }
            // File
            else if ("file".Equals(uri.Scheme, StringComparison.OrdinalIgnoreCase))
                return uri.Path;
            return null;
        }
