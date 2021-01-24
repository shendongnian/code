    DriveClass.DriveApi.NewDriveContents(client).SetResultCallback(new System.Action<IDriveApiDriveContentsResult>((result)=> {
                //Create MetadataChangeSet
                MetadataChangeSet metadataChangeSet = new MetadataChangeSet.Builder()
                    .SetTitle("Test.jpg")
                    .SetMimeType("image/jpeg").Build();
                var contents = result.DriveContents;
                //create the bitmap
                Bitmap bitmap = CreateBitmap(800, 800);
                //push the bitmap data to DriveContents
                bitmap.Compress(CompressFormat.Jpeg, 1, contents.OutputStream);
                IntentSender intentSender = DriveClass.DriveApi
                        .NewCreateFileActivityBuilder()
                        .SetInitialMetadata(metadataChangeSet)
                        .SetInitialDriveContents(contents)
                        .Build(client);
                StartIntentSenderForResult(intentSender, 2, null, 0, 0, 0);
            }));
