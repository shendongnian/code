        [CustomAuthorization(IdentityRoles = "AdjustmentsView")]
        public ActionResult AdjustmentIndex()
        {
            var adjlist = _Adj.GetAdjustmentHead();
            List<AdjustmentHeadViewModel> adjustlist = new List<AdjustmentHeadViewModel>();
            foreach (var item in adjlist)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<AdjustmentHead, AdjustmentHeadViewModel>());
                AdjustmentHeadViewModel entity = Mapper.Map<AdjustmentHead, AdjustmentHeadViewModel>(item);
                adjustlist.Add(entity);
            }
            return View(adjustlist);
        }
