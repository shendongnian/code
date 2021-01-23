    public List<Payments> getAllPayemtns(Guid _customerId)
        {
            List<Payments> AllPayments = new List<Payments>();
            List<tblPortalPayment> _payments = portalEntities.tblPortalPayments.Where(a => a.CustomerId == _customerId && a.isDeleted == false).ToList();
            foreach (var payment in _payments)
            {
                AllPayments.Add(new Payments(payment.id, Convert.ToDecimal(payment.paymentDue), Convert.ToDateTime(payment.paymentDate), Convert.ToBoolean(payment.isinArrears));
            }
            List<tblPortalContributionSchedule> _contributions = portalEntities.tblPortalContributionSchedules.Where(a => a.customerInfo == _customerId && a.isDeleted == false && a.DUE_DATE <= _date && a.DUE_DATE != _date).Take(6).OrderByDescending(o => o.DUE_DATE).ToList();
            foreach (var contribution in _contributions)
            {
                AllPayments.Add(new Payments(contribution.ID, Convert.ToDecimal(contribution.Contribution), Convert.ToDateTime(contribution.DUE_DATE), false));
            }
     return AllPayments;
    }
