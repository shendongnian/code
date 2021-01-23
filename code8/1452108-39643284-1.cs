    /// <summary>
    /// Advances the reader to the next record.
    /// If HasHeaderRecord is true (true by default), the first record of
    /// the CSV file will be automatically read in as the header record
    /// and the second record will be returned.
    /// </summary>
    /// <returns>True if there are more records, otherwise false.</returns>
    public virtual bool Read()
    {
        if (doneReading)
        {
            throw new CsvReaderException(DoneReadingExceptionMessage);
        }
    
        if (configuration.HasHeaderRecord && headerRecord == null)
        {
            ReadHeader();
        }
    
        do
        {
            currentRecord = parser.Read();
        }
        while (ShouldSkipRecord());
    
        currentIndex = -1;
        hasBeenRead = true;
    
        if (currentRecord == null)
        {
            doneReading = true;
        }
    
        return currentRecord != null;
    }
    
    /// <summary>
    /// Checks if the current record should be skipped or not.
    /// </summary>
    /// <returns><c>true</c> if the current record should be skipped, <c>false</c> otherwise.</returns>
    protected virtual bool ShouldSkipRecord()
    {
        if (currentRecord == null)
        {
            return false;
        }
    
        return configuration.ShouldSkipRecord != null
            ? configuration.ShouldSkipRecord(currentRecord)
            : configuration.SkipEmptyRecords && IsRecordEmpty(false);
    }
