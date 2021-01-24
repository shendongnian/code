    public void AddMemberEligibility(long memberId, int planSponsorId, int vendorId, string vendorContractKey, ...) {
        using (IDocumentSession session = Global.DocumentStore.OpenSession()) {
            MemberEligibility elig = new MemberEligibility() {
                MemberId = memberId,
                PlanSponsorId = planSponsorId,
                VendorId = vendorId,
                VendorContractKey = vendorContractKey,
                //other stuff
            };
            var existing = session.LoadByUniqueConstraint<MemberEligibility>(x => x.EligibilityKey, elig.EligibilityKey);
            if (existing != null) {
                // set some fields
            } else {
                session.Store(elig);
            }
            session.SaveChanges();
        }
    }
