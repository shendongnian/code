     //POST: Quote/SubGroupByGroup
        [HttpPost]
        public ActionResult SubGroupByGroup(int _EquipmentGroupID)
        {
            string Options = "";
            DAL.GetEquipmentSubGroupsDropdown(_EquipmentGroupID).ForEach(delegate (EquipmentSubGroup SG)
            {
                Options += "<option value='" + SG.EquipmentGroupID + "'>" + SG.Code + "</option>";
            });
            return Content(Options);
        }
