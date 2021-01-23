    public class Results
    {
        public int skip { get; set; }
        public int limit { get; set; }
        public int total { get; set; }
    }
    
    public class Meta
    {
        public string disclaimer { get; set; }
        public string terms { get; set; }
        public string license { get; set; }
        public string last_updated { get; set; }
        public Results results { get; set; }
    }
    
    public class Openfda
    {
        public List<string> product_ndc { get; set; }
        public List<string> nui { get; set; }
        public List<string> package_ndc { get; set; }
        public List<string> generic_name { get; set; }
        public List<string> spl_set_id { get; set; }
        public List<string> pharm_class_cs { get; set; }
        public List<string> brand_name { get; set; }
        public List<string> original_packager_product_ndc { get; set; }
        public List<string> manufacturer_name { get; set; }
        public List<string> unii { get; set; }
        public List<string> spl_id { get; set; }
        public List<string> substance_name { get; set; }
        public List<string> product_type { get; set; }
        public List<string> route { get; set; }
        public List<string> application_number { get; set; }
        public List<string> pharm_class_epc { get; set; }
        public List<bool?> is_original_packager { get; set; }
        public List<string> upc { get; set; }
        public List<string> rxcui { get; set; }
    }
    
    public class Result
    {
        public string effective_time { get; set; }
        public List<string> spl_unclassified_section_table { get; set; }
        public List<string> inactive_ingredient { get; set; }
        public List<string> instructions_for_use { get; set; }
        public List<string> purpose { get; set; }
        public List<string> keep_out_of_reach_of_children { get; set; }
        public List<string> spl_patient_package_insert { get; set; }
        public List<string> warnings { get; set; }
        public List<string> description { get; set; }
        public List<string> spl_product_data_elements { get; set; }
        public Openfda openfda { get; set; }
        public string version { get; set; }
        public List<string> dosage_and_administration { get; set; }
        public List<string> spl_unclassified_section { get; set; }
        public List<string> storage_and_handling { get; set; }
        public List<string> package_label_principal_display_panel { get; set; }
        public List<string> indications_and_usage { get; set; }
        public string set_id { get; set; }
        public string id { get; set; }
        public List<string> spl_patient_package_insert_table { get; set; }
        public List<string> active_ingredient { get; set; }
        public List<string> drug_interactions { get; set; }
        public List<string> geriatric_use { get; set; }
        public List<string> precautions { get; set; }
        public List<string> pharmacodynamics { get; set; }
        public List<string> general_precautions { get; set; }
        public List<string> pharmacokinetics { get; set; }
        public List<string> teratogenic_effects { get; set; }
        public List<string> dosage_and_administration_table { get; set; }
        public List<string> pediatric_use { get; set; }
        public List<string> contraindications { get; set; }
        public List<string> storage_and_handling_table { get; set; }
        public List<string> pregnancy { get; set; }
        public List<string> nursing_mothers { get; set; }
        public List<string> adverse_reactions { get; set; }
        public List<string> how_supplied_table { get; set; }
        public List<string> laboratory_tests { get; set; }
        public List<string> how_supplied { get; set; }
        public List<string> information_for_patients { get; set; }
        public List<string> clinical_pharmacology { get; set; }
        public List<string> carcinogenesis_and_mutagenesis_and_impairment_of_fertility { get; set; }
        public List<string> overdosage { get; set; }
        public List<string> recent_major_changes { get; set; }
        public List<string> nonclinical_toxicology { get; set; }
        public List<string> dosage_forms_and_strengths { get; set; }
        public List<string> mechanism_of_action { get; set; }
        public List<string> clinical_studies_table { get; set; }
        public List<string> adverse_reactions_table { get; set; }
        public List<string> warnings_and_cautions { get; set; }
        public List<string> recent_major_changes_table { get; set; }
        public List<string> animal_pharmacology_and_or_toxicology { get; set; }
        public List<string> use_in_specific_populations { get; set; }
        public List<string> clinical_studies { get; set; }
        public List<string> clinical_pharmacology_table { get; set; }
        public List<string> instructions_for_use_table { get; set; }
        public List<string> pharmacodynamics_table { get; set; }
    }
    
    public class RootObject
    {
        public Meta meta { get; set; }
        public List<Result> results { get; set; }
    }
