        [HttpPost]
        [AcceptVerbs("POST")]
        async public Task Inventory(long TenantId)
        {
            try
            {
                byte[] data = await Request.Content.ReadAsByteArrayAsync();
                string JsonInventory = System.Text.Encoding.Default.GetString(data);
                List<Inventory> lstInventory = JsonConvert.DeserializeObject<List<Inventory>>(JsonInventory);
                foreach (var item in lstInventory)
                {
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
