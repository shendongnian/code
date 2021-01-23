        public class SOOrderEntryExt : PXGraphExtension<SOOrderEntry>
        {
            public PXAction<SOOrder> ExportAttachmnts;
            [PXButton]
            [PXUIField(DisplayName = "Export Attachments")]
            protected void exportAttachmnts()
            {
                var order = Base.Document.Current;
                PXLongOperation.StartOperation(Base, () =>
                {
                    using (MemoryStream stream = new MemoryStream())
                    {
                        using (PX.Common.ZipArchive archive = PX.Common.ZipArchive.CreateFrom(stream, false))
                        {
                            UploadFileMaintenance upload = PXGraph.CreateInstance<UploadFileMaintenance>();
                            Guid[] uids = PXNoteAttribute.GetFileNotes(Base.Document.Cache, order);
                            foreach (Guid uid in uids)
                            {
                                PX.SM.FileInfo fileInfo = upload.GetFile(uid);
                                archive.AddFile(fileInfo.Name, fileInfo.BinData);
                            }
                        }
                        PX.SM.FileInfo info = new PX.SM.FileInfo(
                            string.Format("{0}-{1}-Attachmets.zip", order.OrderType, order.OrderNbr),
                            null, stream.ToArray());
                        throw new PXRedirectToFileException(info, true);
                    }
                });
            }
        }
