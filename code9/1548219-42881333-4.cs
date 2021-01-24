    public async Task<short> RemoveAsync(int orderID, OrderItemDTO item)
        {
            if (item.LineNumber != 0)
            {
                throw new ValidationException("LineNumber is generated and cannot be specified");
            }
    
            var objToDelete = _db.OrderItems.Where(oi => oi.OrderID == orderID && oi.LineNumber == item.LineNumber);
    
            _db.OrderItems.Remove(objToDelete);    
    
            await _db.SaveChangesAsync();
    
            return xxx ;  //replace what you want to return
        }
