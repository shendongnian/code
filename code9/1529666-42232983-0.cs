    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            
            static void Main(string[] args)
            {
                DataTable Articles = new DataTable();
                Articles.Columns.Add("ArticleID", typeof(int));
                Articles.Rows.Add(new object[] { 1 });
                Articles.Rows.Add(new object[] { 2 });
                Articles.Rows.Add(new object[] { 3 });
                Articles.Rows.Add(new object[] { 4 });
                DataTable ArticleVersions = new DataTable();
                ArticleVersions.Columns.Add("ArticleID", typeof(int));
                ArticleVersions.Columns.Add("Version", typeof(string));
                ArticleVersions.Columns.Add("Title", typeof(string));
                ArticleVersions.Rows.Add(new object[] { 1, "a", "abc" });
                ArticleVersions.Rows.Add(new object[] { 1, "b", "def" });
                ArticleVersions.Rows.Add(new object[] { 1, "a", "ghi" });
                ArticleVersions.Rows.Add(new object[] { 1, "c", "jkl" });
                ArticleVersions.Rows.Add(new object[] { 2, "a", "mno" });
                ArticleVersions.Rows.Add(new object[] { 2, "b", "pqr" });
                ArticleVersions.Rows.Add(new object[] { 2, "a", "stu" });
                ArticleVersions.Rows.Add(new object[] { 3, "c", "vwx" });
                ArticleVersions.Rows.Add(new object[] { 4, "a", "yz" });
                ArticleVersions.Rows.Add(new object[] { 4, "b", "acd" });
                ArticleVersions.Rows.Add(new object[] { 4, "a", "ghi" });
                ArticleVersions.Rows.Add(new object[] { 4, "c", "nop" });
                DataTable ArticleCategoriesVersions = new DataTable();
                ArticleCategoriesVersions.Columns.Add("ArticleID", typeof(int));
                ArticleCategoriesVersions.Columns.Add("CategoryID", typeof(int));
                ArticleCategoriesVersions.Rows.Add(new object[] { 1,  10 });
                ArticleCategoriesVersions.Rows.Add(new object[] { 1,  11 });
                ArticleCategoriesVersions.Rows.Add(new object[] { 1,  12 });
                ArticleCategoriesVersions.Rows.Add(new object[] { 1,  21 });
                ArticleCategoriesVersions.Rows.Add(new object[] { 1,  22 });
                ArticleCategoriesVersions.Rows.Add(new object[] { 1,  35 });
                ArticleCategoriesVersions.Rows.Add(new object[] { 1,  36 });
                ArticleCategoriesVersions.Rows.Add(new object[] { 1,  37 });
                DataTable ArticleCategories = new DataTable();
                ArticleCategories.Columns.Add("CategoryID", typeof(int));
                ArticleCategories.Columns.Add("Name", typeof(string));
                ArticleCategories.Rows.Add(new object[] { 10, "article1" });
                ArticleCategories.Rows.Add(new object[] { 36, "article2" });
                ArticleCategories.Rows.Add(new object[] { 36, "article3" });
                ArticleCategories.Rows.Add(new object[] { 36, "article4" });
                ArticleCategories.Rows.Add(new object[] { 36, "article5" });
                ArticleCategories.Rows.Add(new object[] { 36, "article6" });
                ArticleCategories.Rows.Add(new object[] { 36, "article1" });
                var results = (from acv in ArticleCategoriesVersions.AsEnumerable()
                               where acv.Field<int>("CategoryID") == 36
                               join ac in ArticleCategories.AsEnumerable() on acv.Field<int>("CategoryID") equals ac.Field<int>("CategoryID")
                               join av in ArticleVersions.AsEnumerable() on acv.Field<int>("ArticleID") equals av.Field<int>("ArticleID")
                               join a in Articles.AsEnumerable() on av.Field<int>("ArticleID") equals a.Field<int>("ArticleID")
                               select new { acv = acv, ac = ac, av = av, a = a })
                               .GroupBy(x => x.av.Field<int>("ArticleID"))
                               .OrderByDescending(x => x.Key)
                               .Select(x => new {
                                   Category1 = x.Where(y => y.av.Field<int>("ArticleID") == 36).Select(y => new { acv = y.acv, ac = y.ac, av = y.av, a = y.a}).ToList(),
                                   Category2 = x.GroupBy(y => y.ac.Field<int>("CategoryID"), z => z).ToDictionary(y => y.Key, z => x.ToList()) 
                               }).ToList();
                    
                    
                 
            }
        }
     
    }
