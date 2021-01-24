     if (!Request.Form.ContainsKey("asset"))
            {
                return BadRequest("Asset cannot be empty");
            }
            Asset asset = JsonConvert.DeserializeObject<Asset>(Request.Form.First(a => a.Key == "asset").Value);
