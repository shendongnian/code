    public static Func<OrderDetail, decimal> calcQtyNeedOD = (od) => (od.OrderedQuantity - od.PickedQuantity);
    public List<AllocationNeedViewModel> ConvertOrderDetailsToViewModel(IQueryable<OrderDetail> qryShipOrderDtls, List<int> itemIdsToExclude, bool boolGroupViewModelByItemAndRemnant)
    {
        return qryShipOrderDtls
            .ToArray()
            .Select(new AllocationNeedViewModel
                {
                    WorkReleaseHeaderId = od.OrderHeader.WorkReleaseHeaderId.Value,
                    OrderHeaderId = od.OrderHeaderId,
                    OrderDetailId = od.Id,
                    ItemId = od.ItemId.Value,
                    ItemDescription = od.Item.Description,
                    IsInventoryTracked = od.Item.TrackInventory,
                    QtyNeed = calcQtyNeedOD(od),
                    QtyRemain = 0,
                    QtyAllocated = 0,
                    IsAllocated = false
                }).ToList();
    }
