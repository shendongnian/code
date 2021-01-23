            var analyzer = new StandardAnalyzer(LuceneVersion.LUCENE_48);
            var config = new IndexWriterConfig(LuceneVersion.LUCENE_48, analyzer);
            config.SetOpenMode(IndexWriterConfig.OpenMode_e.CREATE_OR_APPEND);
            var indexPathBlog = "D:\\Test";
            if (System.IO.Directory.Exists(indexPathBlog))
            {
                System.IO.Directory.Delete(indexPathBlog, true);
            }
            System.IO.Directory.CreateDirectory(indexPathBlog);
            var indexDirectoryBlog = FSDirectory.Open(new System.IO.DirectoryInfo(indexPathBlog));
            var indexWriterBlog = new IndexWriter(indexDirectoryBlog, config);
            var one = new List<Document>();
            var two = new List<Document>();
            var blogOne = new Document();
            blogOne.Add(new TextField("Id", "1", Field.Store.YES));
            blogOne.Add(new TextField("BlogContent", "Content of first blog", Field.Store.YES));
            blogOne.Add(new TextField("Type", "blog", Field.Store.YES));
            blogOne.Add(new TextField("Note", "parent", Field.Store.YES));
            one.Add(blogOne);
            Document commentOne = new Document();
            commentOne.Add(new TextField("BlogId", "1", Field.Store.YES));
            commentOne.Add(new TextField("CommentContent", "I like your first blog!", Field.Store.YES));
            commentOne.Add(new TextField("Type", "comment", Field.Store.YES));
            commentOne.Add(new TextField("Note", "child", Field.Store.YES));
            one.Add(commentOne);
            Document blogTwo = new Document();
            blogTwo.Add(new TextField("Id", "2", Field.Store.YES));
            blogTwo.Add(new TextField("BlogContent", "This is the second blog!", Field.Store.YES));
            blogTwo.Add(new TextField("Type", "blog", Field.Store.YES));
            blogTwo.Add(new TextField("Note", "parent", Field.Store.YES));
            two.Add(blogTwo);
            var commentTwo = new Document();
            commentTwo.Add(new TextField("BlogId", "2", Field.Store.YES));
            commentTwo.Add(new TextField("CommentContent", "Not that great.", Field.Store.YES));
            commentTwo.Add(new TextField("Type", "comment", Field.Store.YES));
            commentTwo.Add(new TextField("Note", "child", Field.Store.YES));
            two.Add(commentTwo);
            indexWriterBlog.AddDocuments(one);
            indexWriterBlog.AddDocuments(two);
            indexWriterBlog.Commit();
            var searcher = new IndexSearcher(DirectoryReader.Open(indexDirectoryBlog));
            Filter parentQuery = 
                    new QueryWrapperFilter(
                      new TermQuery(
                        new Term("type", "blog")));
            BooleanQuery childQuery = new BooleanQuery();
            childQuery.Add(new TermQuery(new Term("CommentContent", "I like your first blog!")), BooleanClause.Occur.MUST);
            var commentJoinQuery = new ToParentBlockJoinQuery(
                childQuery,
                parentQuery,
                ScoreMode.None);
            BooleanQuery query = new BooleanQuery();
            //query.Add(new TermQuery(new Term("Type", "blog")), BooleanClause.Occur.MUST);
            query.Add(commentJoinQuery, BooleanClause.Occur.MUST);
            var c = new ToParentBlockJoinCollector(
                Sort.RELEVANCE, // sort
                10,             // numHits
                false,           // trackScores
                false           // trackMaxScore
                );
            searcher.Search(commentJoinQuery, c);
            int maxDocsPerGroup = 10;
            var hits = c.GetTopGroups(
                commentJoinQuery,
                Sort.INDEXORDER,
                0,   // offset
                maxDocsPerGroup,  // maxDocsPerGroup
                0,   // withinGroupOffset
                true // fillSortFields
              );
            if (hits != null)
            {
                Console.WriteLine("Found " + hits.TotalGroupCount + " groups:");
                for (int i = 0; i < hits.TotalGroupCount; i++)
                {
                    var group = hits.Groups[i];
                    Console.WriteLine("Group " + i + ": " + group.ToString());
                    for (int j = 0; j < group.TotalHits && j < maxDocsPerGroup; j++)
                    {
                        Document doc = searcher.Doc(group.ScoreDocs[j].Doc);
                        Console.WriteLine("Hit " + i + ": " + doc.ToString());
                    }
                }
            }
            else
            {
                Console.WriteLine("No hits.");
            }
            Console.WriteLine("Done.");
