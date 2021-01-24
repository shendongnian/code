    if (voterSearchModel.FirstNameSearch != null)
    {
        voters = voters.Where(voter.First_Name.Contains(voterSearchModel.FirstNameSearch);
    }
    if (voterSearchModel.LastNameSearch != null)
    {
        voters = voters.Where(voter.Last_Name.Contains(voterSearchModel.LastNameSearch);
    }
    if (voterSearchModel.AddressSearch != null)
    {
        voters = voters.Where(voter.StreetNameComplete.Contains(voterSearchModel.AddressSearch);
    }
