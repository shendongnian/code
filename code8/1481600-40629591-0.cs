    DataTable dt = GetDataTableByIndex(data, 1);
    if (dt != null && dt.Rows.Count > 0)
    {
          providerQualification.ProviderDetails = new List<ProviderDetail>();
          ProviderDetail providerDetail;
          foreach (DataRow row in dt.Rows)
          {    
              providerDetail = new ProviderDetail();
              providerDetail.ProviderName = row["Provider Name"].ToString();
              providerDetail.QualificationTime = row["Qualify Time (Sec.)"].ToString();
              providerDetail.ServiceableOffers = row["Total Serviceable Offers"].ToString();
              providerQualification.ProviderDetails.Add(providerDetail);
          }
      }
