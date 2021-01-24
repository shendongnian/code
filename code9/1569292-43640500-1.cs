    public JsonResult getViewsAssigned(string candidateIds)
    {
        List<long> idList = candidateIds.Split(',').Select(long.Parse).ToList();
        long clientId = webRequestState.ClientId.Value;
        long clientUserId = webRequestState.ClientUserId.Value;
        return Json(clientViewService.getViewsAssignedToCandidates(idList, clientId, clientUserId), JsonRequestBehavior.AllowGet);
    }
