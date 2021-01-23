      public class PayPalViewModel
        {
            public string mc_gross { get; set; }
            public string custom { get; set; }
            public string payment_status { get; set; }
    
            public string payment_type { get; set; }
            public string mc_currency { get; set; }
    
            public string payer_id { get; set; }
            public DateTime payment_date { get; set; }
            public string payment_gross { get; set; }
    
            /// <summary>
            /// ToPayPalVM From NameValueCollection
            /// </summary>
            /// <returns></returns>
            public PayPalViewModel ToPayPalVM(NameValueCollection qscoll)
            {
                if (qscoll == null) return null;
                DateTime date = DateTime.Now;
                string mcGross = qscoll["mc_gross"];
                string paymentType = qscoll["payment_type"];
                string mcCurrency = qscoll["mc_currency"];
                string paymentStatus = qscoll["payment_status"];
                string payerId = qscoll["payer_id"];
                string paymentDate = qscoll["payment_date"];
                string paymentGross = qscoll["payment_gross"];
                string cust = qscoll["custom"];
    
                var datePay = DateTime.TryParse(paymentDate, out date);
    
                return new PayPalViewModel
                {
                    mc_gross = mcGross,
                    custom = cust,
                    payment_status = paymentStatus,
                    payment_type = paymentType,
                    mc_currency = mcCurrency,
                    payer_id = payerId,
                    payment_gross = paymentGross,
                    payment_date = (datePay) ? date : DateTime.Now
                };
            }
        }
