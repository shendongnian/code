    from c in ProjectMstr
    join pm in ParamsMstr on c.ChClass equals pm.ParamId
    join pm2 in ParamsMstr on c.ChClass equals pm2.ParamId
    join pm3 in ParamsMstr on c.ChClass equals pm3.ParamId
    // …
    where pm.ParamCd == "CH_CLASS"
    where pm.ParamCd == "CH_TYP"
    where pm.ParamCd == "CH_GRP"
    orderby c.CreaDt descending
    select new {
        c.ChId,
        // …
        ProjectClass = pm.ParamVal,
        ProjectType = pm2.ParamVal,
        ProjectGroup = pm3.ParamVal,
    }
