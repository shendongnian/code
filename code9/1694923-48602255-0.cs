     private RepairOrder _selectedRepairOrder;
     public RepairOrder SelectedRepairOrder
            {
                get { return _selectedRepairOrder; }
                set
                {
                    if (_selectedRepairOrder == value) return;
                    _selectedRepairOrder = value;
                    NotifyOfPropertyChange(() => SelectedRepairOrder);
                    NotifyOfPropertyChange(() => WriteOffsCollection);
                }
            }
