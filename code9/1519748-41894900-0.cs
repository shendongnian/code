    var HOQuotePremiums = (from holoc in objRes.ResHO.HOLocations
                                                   from cst in ((HOLocation)holoc).HOBuildings
                                                   select new
                                                   {
                                                       RequestId = cst.HOPremium.RequestId,
                                                       BasePremium = Convert.ToInt32(cst.HOPremium.BasePremium),
                                                       PersonalLiabilityPremium = cst.HOPremium.PersonalLiabilityPremium,
                                                       MedicalPaymentPremium = cst.HOPremium.MedicalPaymentPremium,
                                                       FinalPremium = objRes.ResHO.FinalPremium,
                                                       WithoutAOPDeductibleFinalPremium = cst.HOPremium.WithoutAOPDeductibleFinalPremium,
                                                       SubTotalPremium = objRes.ResHO.FinalPremiumWithoutFeeTax,
                                                       LocationID = holoc.LocationID,
                                                       BuildingID = cst.BuildingID,
                                                       IsMinimumPremium = cst.HOPremium.IsMinimumPremium,
                                                       MinimumPremium = cst.HOPremium.MinimumPremium,
                                                       SubTotalPremiumWithoutMinimumPremium = cst.HOPremium.SubTotalPremiumWithoutMinimumPremium,
                                                       FinalRate=cst.HOPremium.FinalRate,
                                                   }).ToList();
