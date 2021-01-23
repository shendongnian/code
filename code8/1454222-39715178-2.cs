    from c in ProjectMstr
    join pm in ParamsMstr on new { ParamId = c.ChClass, ParamCd = "CH_CLASS" } equals new { pm.ParamId, pm.ParamCd }
    join pm2 in ParamsMstr on new { ParamId = c.ChClass, ParamCd = "CH_TYP" } equals new { pm2.ParamId, pm2.ParamCd }
    join pm3 in ParamsMstr on new { ParamId = c.ChClass, ParamCd = "CH_GRP" } equals new { pm3.ParamId, pm3.ParamCd }
    // …
    orderby c.CreaDt descending
    select new {
        c.ChId,
        // …
        ProjectClass = pm.ParamVal,
        ProjectType = pm2.ParamVal,
        ProjectGroup = pm3.ParamVal,
    }
