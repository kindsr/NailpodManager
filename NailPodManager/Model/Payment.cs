using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace NailPodManager.Model
{
    public partial class Payment
    {
        [JsonProperty("payment_id")]
        public int PaymentId { get; set; }

        [JsonProperty("machine_id")]
        public int MachineId { get; set; }

        [JsonProperty("customer_id")]
        public int CustomerId { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("approval_no")]
        public string ApprovalNo { get; set; }

        [JsonProperty("card_owner")]
        public string CardOwner { get; set; }

        [JsonProperty("card_type")]
        public string CardType { get; set; }

        [JsonProperty("card_comp")]
        public string CardComp { get; set; }

        [JsonProperty("payment_dt")]
        public DateTimeOffset? PaymentDt { get; set; }

        [JsonProperty("cancel_yn")]
        public string CancelYn { get; set; }

        [JsonProperty("cancel_approval_no")]
        public string CancelApprovalNo { get; set; }

        [JsonProperty("error_cd")]
        public string ErrorCd { get; set; }

        [JsonProperty("error_msg")]
        public string ErrorMsg { get; set; }

        //[JsonProperty("reg_dt")]
        //public DateTime RegDt { get; set; }

        //[JsonProperty("upd_dt")]
        //public DateTime UpdDt { get; set; }
    }

    public partial class Payment
    {
        public static Payment[] FromJson(string json) => JsonConvert.DeserializeObject<Payment[]>(json, Converter.Settings);
    }
    public static class SerializePayment
    {
        public static string ToJson(this Payment[] self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
}
