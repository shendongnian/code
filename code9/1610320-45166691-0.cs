        session.StartLog("CheckingConfig");
        CheckConfiguration(session);
        return ActionResult.Success;
    could be replaced with something like
        session.StartLog("CheckingConfig");
        CheckConfiguration(session).Wait();
        return ActionResult.Success;
