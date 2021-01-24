            if (id == 0)
            {
                _context.Add(model);
                for (var items = 0; items < model.NumDevices; items++)
                {
                    var contador = items + 1;
                    string devicename = model.MchName + "-" + contador.ToString();
                    var devNew = new Device();
                    devNew.DeviceName = devicename;
                    _context.Add(devNew);
                    await _context.SaveChangesAsync();
                }
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
