    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Data;
    using System.Globalization;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Branch> branches = new List<Branch>() {
                    new Branch() {
                        Id = 1,
                        Name = "Branch:1",
                        Deposits = new List<Deposit>(){
                            new Deposit{
                                Id=1,
                                DateOfDeposit = DateTime.ParseExact("01/01/2016","dd/MM/yyyy",CultureInfo.InvariantCulture),
                                Amount=50
                            },
                            new Deposit() {
                                Id=2,
                                DateOfDeposit = DateTime.ParseExact("05/02/2017","dd/MM/yyyy",CultureInfo.InvariantCulture),
                                Amount = 30
                            },
                            new Deposit() {
                                Id=3,
                                DateOfDeposit = DateTime.ParseExact("01/01/2017","dd/MM/yyyy",CultureInfo.InvariantCulture),
                                Amount = 30
                            }
                        }
                    },
                    new Branch() {
                        Id = 2,
                        Name = "Branch:2",
                        Deposits = new List<Deposit>() {
                            new Deposit{
                                Id=1,
                                DateOfDeposit = DateTime.ParseExact("01/01/2016","dd/MM/yyyy",CultureInfo.InvariantCulture),
                                Amount=50
                            },
                            new Deposit() {
                                Id=2,
                                DateOfDeposit = DateTime.ParseExact("05/02/2017","dd/MM/yyyy",CultureInfo.InvariantCulture),
                                Amount = 30
                            },
                            new Deposit() {
                                Id=3,
                                DateOfDeposit = DateTime.ParseExact("01/01/2017","dd/MM/yyyy",CultureInfo.InvariantCulture),
                                Amount = 30
                            }
                        }
                    }
                };
                var results = branches.Select(x => new {
                    Id = x.Id,
                    month1Deposits = x.Deposits.Where(y => y.DateOfDeposit >= DateTime.Now.AddMonths(-1)).Count(),
                    month2Deposits = x.Deposits.Where(y => y.DateOfDeposit >= DateTime.Now.AddMonths(-2)).Count(),
                    month3Deposits = x.Deposits.Where(y => y.DateOfDeposit >= DateTime.Now.AddMonths(-3)).Count(),
                    month4Deposits = x.Deposits.Where(y => y.DateOfDeposit >= DateTime.Now.AddMonths(-4)).Count(),
                    month5Deposits = x.Deposits.Where(y => y.DateOfDeposit >= DateTime.Now.AddMonths(-5)).Count(),
                    month6Deposits = x.Deposits.Where(y => y.DateOfDeposit >= DateTime.Now.AddMonths(-6)).Count(),
                    month7Deposits = x.Deposits.Where(y => y.DateOfDeposit >= DateTime.Now.AddMonths(-7)).Count(),
                    month8Deposits = x.Deposits.Where(y => y.DateOfDeposit >= DateTime.Now.AddMonths(-8)).Count(),
                    month9Deposits = x.Deposits.Where(y => y.DateOfDeposit >= DateTime.Now.AddMonths(-8)).Count(),
                    month10Deposits = x.Deposits.Where(y => y.DateOfDeposit >= DateTime.Now.AddMonths(-10)).Count(),
                    month11Deposits = x.Deposits.Where(y => y.DateOfDeposit >= DateTime.Now.AddMonths(-11)).Count(),
                    month12Deposits = x.Deposits.Where(y => y.DateOfDeposit >= DateTime.Now.AddMonths(-12)).Count()
                }).ToList();
                
            }
        }
        public class Branch
        {
            public int Id { get; set;}
            public string Name { get; set;}
            public List<Deposit> Deposits { get; set;}
        }
        public class Deposit
        {
            public int Id { get; set;}
            public DateTime  DateOfDeposit { get; set;}
            public int Amount { get; set;}
        }
     
    }
