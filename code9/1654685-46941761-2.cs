    public static bool IsUniquePermit(TextBox textbox, List<IBuildingPermit> buildingPermitList)
        {
            foreach (IBuildingPermit bp in buildingPermitList)
            {
                if (textbox.Text == bp.permitNo)
                {
                    MessageBox.Show("That permit number has been previously issued");
                    return false;
                }
                else
                {
                    return true;
                }
            }
    }
