    [HttpPost]
        [Route("API/PayPalReg")]
        public JsonResult ReceiveInput(string txn_id, string payment_date,
                                    string payer_email, string payment_status, 
                                    string first_name, string last_name, 
                                    string item_number, string item_name, 
                                    string payer_id, string verify_sign)
        {
            var paypaltypes = item_name.Split('-');
            var result = item_number.Split('-');
            var userid = int.Parse(result[1]);
            var TransPaymentString = result[1].ToString() + result[0].ToString();
            var TransPayment = int.Parse(TransPaymentString);
            var user = _context.Person.Include(p => p.Payments).Where(p => p.UserID == userid).Single();
            var payment = user.Payments.Where(p => p.TransPaymentID == TransPayment).Single();
            if (paypaltypes[0] == "Event")
            {
                var eventid = int.Parse(result[0]);
                payment.PaymentReceipt = txn_id;
                payment.PaymentReceived = true;
                payment.PaymentReceivedDate = DateTime.Now;
                payment.PaymentNotes = payer_email + " " + first_name + " " + last_name + " " + item_number + " " + payer_id + " " + verify_sign + " " + item_name;
                _context.Payments.Update(payment);
                _context.SaveChanges();
                var userevent = _context.Person.Include(p => p.EventRegistry).Where(p => p.UserID == userid).Single();
                var eventreg = userevent.EventRegistry.Where(er => er.EventID == eventid).Single();
                eventreg.EventPaid = true;
                _context.EventRegistry.Update(eventreg);
                _context.SaveChanges();
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json("Json Result");
            }
