        [DjvuTheory]
        [ClassData(typeof(DjvuJsonDataSource))]
        public void DirmChunk_Theory(DjvuJsonDocument doc, int index)
        {
            int pageCount = 0;
            using (DjvuDocument document = DjvuNet.Tests.Util.GetTestDocument(index, out pageCount))
            {
                DjvuNet.Tests.Util.VerifyDjvuDocument(pageCount, document);
                DjvuNet.Tests.Util.VerifyDjvuDocumentCtor(pageCount, document);
                // DirmChunk is present only in multi page documents
                // in which root form is of DjvmChunk type
                if (document.RootForm.ChunkType == ChunkType.Djvm)
                {
                    DirmChunk dirm = ((DjvmChunk)document.RootForm).Dirm;
                    Assert.NotNull(dirm);
                    Assert.True(dirm.IsBundled ? doc.Data.Dirm.DocumentType == "bundled" : doc.Data.Dirm.DocumentType == "indirect");
                    var components = dirm.Components;
                    Assert.Equal<int>(components.Count, doc.Data.Dirm.FileCount);
                }
            }
        }
