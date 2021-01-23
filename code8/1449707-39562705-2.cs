    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ReservationTableIssue
    {
        class Program
        {
            static void Main(string[] args)
            {
                            
                TableRepository repo = new TableRepository();
    
                // step #1 - figure out the 24 hour period you need to find reserved tables for
                // it is advisible when searching by date to use a date range instead of once specific date
                // the start date and end date will satisfy the 24 hour period of tomorrow.
    
                // get start tomorrow
                DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddDays(1);
    
                // get end of tomorrow
                DateTime endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddDays(2);
    
                // call the repository method with the date range (the 24 hour period for tomorrow)
                var tablesForTomorrow = repo.GetAllReservedTables(startDate, endDate);
    
                // dispaly data in console
                foreach(var table in tablesForTomorrow)
                {
                    Console.WriteLine("Table Number: #{0}", table.Numero);
                }
    
                Console.WriteLine("press any key to exit");
                Console.ReadKey();
    
            }
        }
    
        public class Table
        {
            public int Id { get; set; }
            public bool isAvailable { get; set; }
            public int Numero { get; set; }
            public virtual ICollection<Reservation> IReservation { get; set; }
        }
    
        public class Reservation
        {
            public DateTime DateReservation { get; set; }
            public int Id { get; set; }
            public string Nom { get; set; }
            public virtual Table table { get; set; }
        }
        public class RestaurantContext :DbContext
        {
            public DbSet<Table> tTable { set; get; }
            public DbSet<Reservation> tReservation { set; get; }
            public RestaurantContext() : base("RestaurentDB") {     
            }
        }
    
        public class TableRepository
        {
            RestaurantContext rc = null;
    
            public TableRepository()
            {
                rc = new RestaurantContext();
            }
            public void Commit()
            {
                rc.SaveChanges();
            }
            public void AddTable(Table m)
            {
                rc.tTable.Add(m);
            }
    
            public IEnumerable<Table> GetAllTables()
            {
                return rc.tTable.ToList();
            }
    
            /// <summary>
            /// A method that allows you to get all tables reserved in a specific period. tables are only returned if they are reserverd.
            /// </summary>
            /// <param name="start"></param>
            /// <param name="end"></param>
            /// <returns></returns>
            public IEnumerable<Table> GetAllReservedTables(DateTime start, DateTime end)
            {
                return this.rc.tReservation
                    // filter by date range
                    .Where(x => x.DateReservation >= start && x.DateReservation <= end)
    
                    // ensure table is returned
                    .Select(x => x.table);
            }
        }
    
    }
