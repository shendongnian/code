    var yearRecords =
        from tdf in ReturnFromCalculatingStartDate
        join tcd in SCH_YR_TRM_CODES on tdf.SchoolYearTermDefGu
            equals tcd.SCHOOL_YEAR_TRM_DEF_GU
        where tcd.TERM_CODE == "YR"
        orderby tcd.TERM_CODE
        group tdf by new
            {
                SchoolId = testOrgGu,
                SchoolYear = testSchoolyear,
                TermCode = tcd.TERM_CODE,
                TermCodeId = tcd.SCHOOL_YEAR_TRM_CODES_GU
        } into yrs
        select new TermResult
        {
            SchoolId = yrs.Key.SchoolId,
            SchoolYear = yrs.Key.testSchoolyear,
            TermCode = yrs.Key.TermCode,
            TermBegin = yrs.Min(x => x.TermBegin),
            TermEnd = yrs.Max(x => x.TermBegin),
            TermCodeId = yrs.Key.TermCodeId
        };
