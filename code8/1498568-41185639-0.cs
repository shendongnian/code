    public async Task<ObservableCollection<Session>> GetSessionsAsync(Conference currentConference, bool syncItems = false)
    {
        try
        {
            var conferenceId = currentConference.Id;
            IEnumerable<Session> sessions = await sessionTable
                            .Where(s => s.ConferenceId == conference.Id)
                            .ToEnumerableAsync();
            return new ObservableCollection<Session>(sessions);
        }
        catch (MobileServiceInvalidOperationException msioe)
        {
            Debug.WriteLine(@"MSIOE exception: {0}", msioe.Message);
        }
        catch (Exception e)
        {
            Debug.WriteLine(@"Some exception: {0}", e.Message);
        }
        return null;
    }
