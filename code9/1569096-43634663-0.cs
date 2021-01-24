    var list = new List<IEmergOpenAct>() { // I am guessing a type here
       CCU_O.MWT.DRSa09_DrEmrgOpn.DRSa09_DrEmrgOpnCst.DCU01_IEmergOpenAct,
       CCU_O.MWT.DRSa09_DrEmrgOpn.DRSa09_DrEmrgOpnCst.DCU02_IEmergOpenAct,
       CCU_O.MWT.DRSa09_DrEmrgOpn.DRSa09_DrEmrgOpnCst.DCU03_IEmergOpenAct,
    };
    foreach (var act in list)
    {
       act.Force(false);
    }
