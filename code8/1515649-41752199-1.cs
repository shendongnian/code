    private List<Patient> PatientsList = new List<Patient>();
    private void AddAddOn_Click(object sender, EventArgs e)
    {
        // Set the data on the patient, name etc.
        patient.PatientFirstName = PatientFirstNameInput.Text;
        patient.PatientLastName = PatientLastNameInput.Text;
        patient.PatientCopay = Convert.ToDecimal(PatientCopayInput.Text);
        patient.BillId = BillIdInput.Text;
        Charge charge;
        // Does the patient already have a Charge in their list?
        if (patient.ChargeList.Count == 0)
        {
            // - if not, add a new charge
            charge = new Charge();
            patient.ChargeList.Add(charge);
        }
        else
        {
            // - if that's the case, use the existing charge but update info
            charge = patient.ChargeList.First();
        }
        // Add a charge to the patient's list of charges
        charge.DateofService = DateofServiceInput.Value.ToString("yyyyMMdd");
        charge.PrimaryProcedureCode = PrimaryProcedureInput.Text;
        charge.PrimaryChargeCost = Convert.ToDecimal(PrimaryChargeInput.Text);
        charge.PrimaryChargeContractualAdjustment = Convert.ToDecimal(PrimaryAdjustmentInput.Text);
        charge.PrimaryPaymentAmount = Convert.ToDecimal(PrimaryPaidInput.Text);
        // Set the name of the Patient
        // Create a new Charge
        // Create an add-on charge and add it to the Charge
        AddonCharge newAddonCharge = new AddonCharge();
        newAddonCharge.AddonProcedureCode = AddonProcedureInput.Text;
        newAddonCharge.AddonChargeCost = Convert.ToDecimal(AddonChargeInput.Text);
        newAddonCharge.AddonContractualAdjustment = Convert.ToDecimal(AddonAdjustmentInput.Text);
        newAddonCharge.AddonPaymentAmount = Convert.ToDecimal(AddonPaidInput.Text);
        charge.AddonChargeList.Add(newAddonCharge);
        List<Patient> patientList = PatientsList;
        patientList.Add(patient);
        //newCharge.AddonChargeList.Add(newAddonCharge);
    }
    private void AddtoListButton_Click(object sender, EventArgs e)
    {
        //return a new patient with null details
        Patient patient = new Patient();
        List<Patient> patientlist = PatientsList;
        // Show a messagebox with the string
        //MessageBox.Show(EDIToString());
    }
