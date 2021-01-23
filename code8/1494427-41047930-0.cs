    public List<ParkingLot> parkingLot;
    public async Task<ActionResult> Index(Position postData)
        {
            string json = new WebClient() { Encoding = Encoding.UTF8 }.DownloadString("json_url_removed_for_post");
            parkingLot = JsonConvert.DeserializeObject<List<ParkingLot>>(json);
            TempData["postData"] = postData;
            TempData["parkingLot"] = parkingLot;
            return View(parkingLot);
         }
