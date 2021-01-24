        public JsonResult ModelsUpdate(string SwitchVal)
        {
            if (SwitchVal == "Weekend")
            {
                resultminDate = CalculateminDate(minDate, todayDay);
            }
            else
            {
                resultminDate = CalculateminDateWeek(minDate, todayDay);
            }
            return Json(resultminDate);
        }
