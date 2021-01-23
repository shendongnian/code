    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            //each time when this objects are accessed, consider as a database call
            private static IQueryable<model1> dbsetModel_1; 
            private static IQueryable<model2> dbsetModel_2;
    
            private static void InitDBSets()
            {
                var rnd = new Random();
                List<model1> dbsetModel1 = new List<model1>();
                List<model2> dbsetModel2 = new List<model2>();
                for (int i = 1; i < 300; i++)
                {
                    if (i % 2 == 0)
                    {
                        dbsetModel1.Add(new model1() { Id = i, OrderNumber = rnd.Next(1, 10), Name = "Test " + i.ToString() });
                    }
                    else
                    {
                        dbsetModel2.Add(new model2() { Id2 = i, OrderNumber2 = rnd.Next(1, 10), Name2 = "Test " + i.ToString() });
                    }
                }
                dbsetModel_1 = dbsetModel1.AsQueryable();
                dbsetModel_2 = dbsetModel2.AsQueryable();
            }
    
            public static void Main()
            {
                //generate sort db data
                InitDBSets();
                //test
                var result2 = GetPage(new PagingFilter() { Page = 5, Limit = 10 });
                var result3 = GetPage(new PagingFilter() { Page = 6, Limit = 10 });
                var result5 = GetPage(new PagingFilter() { Page = 7, Limit = 10 });
                var result6 = GetPage(new PagingFilter() { Page = 8, Limit = 10 });
                var result7 = GetPage(new PagingFilter() { Page = 4, Limit = 20 });
                var result8 = GetPage(new PagingFilter() { Page = 200, Limit = 10 });
    
            }
    
    
            private static PagedList<Item> GetPage(PagingFilter filter)
            {
                int pos = 0;
                //load only start pages intervals margins from both database
                //this part need to be transformed in a stored procedure on db one, skip, take to return interval start value for each frame 
                var framesBordersModel1 = new List<Item>();
                dbsetModel_1.OrderBy(x => x.Id).ThenBy(z => z.OrderNumber).ToList().ForEach(i => {
                    pos++;
                    if (pos - 1 == 0)
                    {
                        framesBordersModel1.Add(new Item() { criteria1 = i.Id, criteria2 = i.OrderNumber, model = i });
                    }
                    else if ((pos - 1) % filter.Limit == 0)
                    {
                        framesBordersModel1.Add(new Item() { criteria1 = i.Id, criteria2 = i.OrderNumber, model = i });
                    }
    
                });
                pos = 0;
                //this part need to be transformed in a stored procedure on db two, skip, take to return interval start value for each frame
                var framesBordersModel2 = new List<Item>();
                dbsetModel_2.OrderBy(x => x.Id2).ThenBy(z => z.OrderNumber2).ToList().ForEach(i => {
                    pos++;
                    if (pos - 1 == 0)
                    {
                        framesBordersModel2.Add(new Item() { criteria1 = i.Id2, criteria2 = i.OrderNumber2, model = i });
                    }
                    else if ((pos -1) % filter.Limit == 0)
                    {
                        framesBordersModel2.Add(new Item() { criteria1 = i.Id2, criteria2 = i.OrderNumber2, model = i });
                    }
    
                });
    
                //decide where is the position of your cursor based on start margins
                //int mainCursor = 0;
                int cursor1 = 0;
                int cursor2 = 0;
                //pages start from 1, page cannot be 0, if indeed you have page 0 change a lil' bit he logic 
                if (framesBordersModel1.Count + framesBordersModel2.Count < filter.Page) throw new Exception("Out of range");
                while ( cursor1 + cursor2 < filter.Page -1)
                {
                    if (framesBordersModel1[cursor1].criteria1 < framesBordersModel2[cursor2].criteria1)
                    {
                        cursor1++;
                    }
                    else if (framesBordersModel1[cursor1].criteria1 > framesBordersModel2[cursor2].criteria1)
                    {
                        cursor2++;
                    }
                    //you should't get here case main key sound't be duplicate, annyhow
                    else
                    {
                        if (framesBordersModel1[cursor1].criteria2 < framesBordersModel2[cursor2].criteria2)
                        {
                            cursor1++;
                        }
                        else
                        {
                            cursor2++;
                        }
                    }
                    //mainCursor++;
                }
                //magic starts
                //inpar skipable
                int skipEndResult = 0;
                List<Item> dbFramesMerged = new List<Item>();
                if ((cursor1 + cursor2) %2 == 0)
                {
                    dbFramesMerged.AddRange(
                        dbsetModel_1.OrderBy(x => x.Id)
                            .ThenBy(z => z.OrderNumber)
                            .Skip(cursor1*filter.Limit)
                            .Take(filter.Limit)
                            .Select(x => new Item() {criteria1 = x.Id, criteria2 = x.OrderNumber, model = x})
                            .ToList()); //consider as db call EF or Stored Procedure
                    dbFramesMerged.AddRange(
                        dbsetModel_2.OrderBy(x => x.Id2)
                            .ThenBy(z => z.OrderNumber2)
                            .Skip(cursor2*filter.Limit)
                            .Take(filter.Limit)
                            .Select(x => new Item() {criteria1 = x.Id2, criteria2 = x.OrderNumber2, model = x})
                            .ToList());
                    ; //consider as db call EF or Stored Procedure
                }
                else
                {
                    skipEndResult = filter.Limit;
                    if (cursor1 > cursor2)
                    {
                        cursor1--;
                    }
                    else
                    {
                        cursor2--;
                    }
                    dbFramesMerged.AddRange(
                       dbsetModel_1.OrderBy(x => x.Id)
                           .ThenBy(z => z.OrderNumber)
                           .Skip(cursor1 * filter.Limit)
                           .Take(filter.Limit)
                           .Select(x => new Item() { criteria1 = x.Id, criteria2 = x.OrderNumber, model = x })
                           .ToList()); //consider as db call EF or Stored Procedure
                    dbFramesMerged.AddRange(
                        dbsetModel_2.OrderBy(x => x.Id2)
                            .ThenBy(z => z.OrderNumber2)
                            .Skip(cursor2 * filter.Limit)
                            .Take(filter.Limit)
                            .Select(x => new Item() { criteria1 = x.Id2, criteria2 = x.OrderNumber2, model = x })
                            .ToList());
                }
    
                IQueryable<Item> qItems = dbFramesMerged.AsQueryable();
                PagedList<Item> result = new PagedList<Item>();
                result.AddRange(qItems.OrderBy(x => x.criteria1).ThenBy(z => z.criteria2).Skip(skipEndResult).Take(filter.Limit).ToList());
                
                //here again you need db cals to get total count
                result.Total = dbsetModel_1.Count() + dbsetModel_2.Count();
                result.Limit = filter.Limit;
                result.Page = filter.Page;
                return result;
            }
        }
    
        public class PagingFilter
        {
            public int Limit { get; set; }
            public int Page { get; set; }
        }
    
    
    
        public class PagedList<T> : List<T>
        {
    
            public int Total { get; set; }
            public int? Page { get; set; }
            public int? Limit { get; set; }
        }
    
        public class Item : Criteria
        {
            public object model { get; set; }
        }
    
        public class Criteria
        {
            public int criteria1 { get; set; }
            public int criteria2 { get; set; }
            //more criterias if you need to order
        }
    
        public class model1
        {
            public int Id { get; set; }
            public int OrderNumber { get; set; }
            public string Name { get; set; }
        }
    
        public class model2
        {
            public int Id2 { get; set; }
            public int OrderNumber2 { get; set; }
            public string Name2 { get; set; }
        }
    }
