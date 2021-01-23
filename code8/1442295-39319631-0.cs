    var query = from c in snd.external_invoices.OrderByDescending(x => x.date)
                            join o in snd.invoices on c.idexternal_invoices equals o.id_external_invoice
                            where c.date== FindDate(c.tipologiaPagamento, c.date)
                            select new
                            {
                                c.idexternal_invoices,
                                c.businessname,
                                o.number,
                                c.message,
                                c.price,
                                c.date,
                                c.tipologiaPagamento,
                                c.esitoPagamento,
                                c.iduser
                            };
      public DateTime FindDate(string tipologiaPagamento, DateTime date)
            {
    
                DateTime Result = new DateTime();
                switch (tipologiaPagamento)
                {
                    case "1":
                        Result = date.AddDays(10);
                        break;
                    case "2":
                        Result = date.AddDays(10);
                        break;
                    case "3":
                        DateTime endOfMonth = new DateTime(date.Year,
                                       date.Month,
                                       DateTime.DaysInMonth(date.Year,
                                                            date.Month));
                        date = endOfMonth;
                        break;
                    case "4":
                        DateTime nextMonth = date.AddMonths(1);
                        DateTime endOfNextMonth = new DateTime(date.Year,
                                      date.Month,
                                       DateTime.DaysInMonth(date.Year,
                                                           date.Month));
                        date = endOfNextMonth;
                        break;
                    default:
                        break;
                }
                return Result;
    
            }
