            IQueryable<IGrouping<AuditReportGroupingDataModelBase, AppEvent>> groupedDataQueryInterm = null;
            if (filters.TimeSpanId == (int)TimeSpanEnum.Daily) groupedDataQueryInterm = dataQuery.GroupBy(e => new AuditReportGroupingDataModelBase { GroupTime = e.InsertDay.Value, CountryId = e.CountryId.Value });
            if (filters.TimeSpanId == (int)TimeSpanEnum.Monthly) groupedDataQueryInterm = dataQuery.GroupBy(e => new AuditReportGroupingDataModelBase { GroupTime = e.InsertMonth.Value, CountryId = e.CountryId.Value });
            if (filters.TimeSpanId == (int)TimeSpanEnum.Yearly) groupedDataQueryInterm = dataQuery.GroupBy(e => new AuditReportGroupingDataModelBase { GroupTime = e.InsertYear.Value, CountryId = e.CountryId.Value });
            if (groupedDataQueryInterm == null)
                throw new InvalidEnumArgumentException($@"Invalid value provided to {nameof(filters.TimeSpanId)}");
            var groupedDataQuery = groupedDataQueryInterm
                .Select(grp => new AuditReportGroupingDataModel
                {
                    GroupTime = grp.Key.GroupTime,
                    CountryId = grp.Key.CountryId,
                    Count = grp.Count()
                })
