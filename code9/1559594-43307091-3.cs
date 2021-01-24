    public List<NightsPerMonth> GetNightsPerMonth(List<BookingRooms> lstBookRooms)
        {
            if (lstBookRooms == null || lstBookRooms.Count == 0) return null;
            var result = new List<NightsPerMonth>();
            var minCheckin = lstBookRooms.Min(x => x.Checkin);
            var maxCheckout = lstBookRooms.Max(x => x.Checkout);
            var currentMonth = minCheckin;
            while (currentMonth <= maxCheckout)
            {
                result.Add(new NightsPerMonth
                {
                    Month = currentMonth.Month,
                    Year = currentMonth.Year,
                    Nights = GetNumberNightsOfMonth(currentMonth, lstBookRooms)
                });
                currentMonth = currentMonth.AddMonths(1);
            }
            return result;
        }
        private int GetNumberNightsOfMonth(DateTime currentMonth, List<BookingRooms> lstBookRooms)
        {
            var startDateOfMonth = new DateTime(currentMonth.Year, currentMonth.Month, 1);
            var endDateOfMonth = startDateOfMonth.AddMonths(1).AddDays(-1);
            return lstBookRooms.Where(x => IsBookRoom(startDateOfMonth, endDateOfMonth, x.Checkin, x.Checkout))
                .Sum(x => NumberNightsBookRoom(startDateOfMonth, endDateOfMonth, x.Checkin, x.Checkout));
        }
        private bool IsBookRoom(DateTime startDateOfMonth, DateTime endDateOfMonth, DateTime checkin, DateTime checkout)
        {
            if (startDateOfMonth >= checkin && startDateOfMonth <= checkout) return true;
            if (endDateOfMonth >= checkin && endDateOfMonth <= checkout) return true;
            if (checkin >= startDateOfMonth && checkin <= endDateOfMonth) return true;
            if (checkout >= startDateOfMonth && checkout <= endDateOfMonth) return true;
            return false;
        }
        private int NumberNightsBookRoom(DateTime startDateOfMonth, DateTime endDateOfMonth, DateTime checkin, DateTime checkout)
        {
            var startTimeSpan = startDateOfMonth <= checkin ? checkin : startDateOfMonth;
            // if Checkout > End of month, then End of month will be calculate as a night
            var endTimeSpan = endDateOfMonth < checkout ? endDateOfMonth.AddDays(1) : checkout;
            return (endTimeSpan - startTimeSpan).Days;
        }
