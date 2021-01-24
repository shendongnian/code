    // To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
    //
    //    using QuickType;
    //
    //    var data = Welcome.FromJson(jsonString);
    //
    namespace QuickType
    {
        using System;
        using System.Net;
        using System.Collections.Generic;
        using Newtonsoft.Json;
    public partial class Welcome
    {
        [JsonProperty("account_holder_name")]
        public string AccountHolderName { get; set; }
        [JsonProperty("account_type")]
        public string AccountType { get; set; }
        [JsonProperty("account_vault_id")]
        public object AccountVaultId { get; set; }
        [JsonProperty("additional_amounts")]
        public object[] AdditionalAmounts { get; set; }
        [JsonProperty("auth_amount")]
        public string AuthAmount { get; set; }
        [JsonProperty("auth_code")]
        public string AuthCode { get; set; }
        [JsonProperty("avs")]
        public object Avs { get; set; }
        [JsonProperty("avs_enhanced")]
        public string AvsEnhanced { get; set; }
        [JsonProperty("batch")]
        public string Batch { get; set; }
        [JsonProperty("billing_city")]
        public object BillingCity { get; set; }
        [JsonProperty("billing_phone")]
        public object BillingPhone { get; set; }
        [JsonProperty("billing_state")]
        public object BillingState { get; set; }
        [JsonProperty("billing_street")]
        public object BillingStreet { get; set; }
        [JsonProperty("billing_zip")]
        public string BillingZip { get; set; }
        [JsonProperty("charge_back_date")]
        public object ChargeBackDate { get; set; }
        [JsonProperty("clerk_number")]
        public object ClerkNumber { get; set; }
        [JsonProperty("contact_id")]
        public string ContactId { get; set; }
        [JsonProperty("created_ts")]
        public long CreatedTs { get; set; }
        [JsonProperty("created_user_id")]
        public string CreatedUserId { get; set; }
        [JsonProperty("customer_id")]
        public object CustomerId { get; set; }
        [JsonProperty("customer_ip")]
        public object CustomerIp { get; set; }
        [JsonProperty("cvv_response")]
        public string CvvResponse { get; set; }
        [JsonProperty("description")]
        public object Description { get; set; }
        [JsonProperty("effective_date")]
        public object EffectiveDate { get; set; }
        [JsonProperty("emv_receipt_data")]
        public object EmvReceiptData { get; set; }
        [JsonProperty("entry_mode_id")]
        public string EntryModeId { get; set; }
        [JsonProperty("first_six")]
        public string FirstSix { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("is_accountvault")]
        public bool IsAccountvault { get; set; }
        [JsonProperty("is_recurring")]
        public bool IsRecurring { get; set; }
        [JsonProperty("last_four")]
        public string LastFour { get; set; }
        [JsonProperty("location_id")]
        public string LocationId { get; set; }
        [JsonProperty("modified_ts")]
        public long ModifiedTs { get; set; }
        [JsonProperty("modified_user_id")]
        public string ModifiedUserId { get; set; }
        [JsonProperty("notification_email_address")]
        public object NotificationEmailAddress { get; set; }
        [JsonProperty("notification_email_sent")]
        public bool NotificationEmailSent { get; set; }
        [JsonProperty("order_num")]
        public string OrderNum { get; set; }
        [JsonProperty("payment_method")]
        public string PaymentMethod { get; set; }
        [JsonProperty("po_number")]
        public object PoNumber { get; set; }
        [JsonProperty("product_transaction_id")]
        public string ProductTransactionId { get; set; }
        [JsonProperty("quick_invoice_id")]
        public object QuickInvoiceId { get; set; }
        [JsonProperty("reason_code_id")]
        public long ReasonCodeId { get; set; }
        [JsonProperty("recurring_id")]
        public object RecurringId { get; set; }
        [JsonProperty("response_message")]
        public object ResponseMessage { get; set; }
        [JsonProperty("return_date")]
        public object ReturnDate { get; set; }
        [JsonProperty("routing")]
        public object Routing { get; set; }
        [JsonProperty("settle_date")]
        public object SettleDate { get; set; }
        [JsonProperty("status_id")]
        public long StatusId { get; set; }
        [JsonProperty("tax")]
        public string Tax { get; set; }
        [JsonProperty("terminal_id")]
        public object TerminalId { get; set; }
        [JsonProperty("terminal_serial_number")]
        public object TerminalSerialNumber { get; set; }
        [JsonProperty("terms_agree")]
        public object TermsAgree { get; set; }
        [JsonProperty("tip_amount")]
        public string TipAmount { get; set; }
        [JsonProperty("transaction_amount")]
        public string TransactionAmount { get; set; }
        [JsonProperty("transaction_api_id")]
        public object TransactionApiId { get; set; }
        [JsonProperty("transaction_c1")]
        public object TransactionC1 { get; set; }
        [JsonProperty("transaction_c2")]
        public object TransactionC2 { get; set; }
        [JsonProperty("transaction_c3")]
        public object TransactionC3 { get; set; }
        [JsonProperty("transaction_code")]
        public object TransactionCode { get; set; }
        [JsonProperty("transaction_settlement_status")]
        public object TransactionSettlementStatus { get; set; }
        [JsonProperty("type_id")]
        public long TypeId { get; set; }
        [JsonProperty("verbiage")]
        public string Verbiage { get; set; }
        [JsonProperty("void_date")]
        public object VoidDate { get; set; }
    }
    public partial class Welcome
    {
        public static Welcome FromJson(string json) => JsonConvert.DeserializeObject<Welcome>(json, Converter.Settings);
    }
    public static class Serialize
    {
        public static string ToJson(this Welcome self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
    public class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
    }
}
