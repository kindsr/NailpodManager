using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace NailPodManager.Model
{
    public partial class ErrorInfo
    {
        [JsonProperty("machine_id")]
        public int MachineId { get; set; }

        [JsonProperty("seq")]
        public int Seq { get; set; }

        [JsonProperty("error_cd")]
        public string ErrorCd { get; set; }

        [JsonProperty("error_msg")]
        public string ErrorMsg { get; set; }

        [JsonProperty("fix_yn")]
        public string FixYn { get; set; }

        [JsonProperty("reg_dt")]
        public DateTimeOffset? RegDt { get; set; }

        //[JsonProperty("upd_dt")]
        //public DateTime UpdDt { get; set; }
    }

    public partial class ErrorInfo
    {
        public static ErrorInfo[] FromJson(string json) => JsonConvert.DeserializeObject<ErrorInfo[]>(json, Converter.Settings);
    }
    public static class SerializeErrorInfo
    {
        public static string ToJson(this ErrorInfo[] self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
}
