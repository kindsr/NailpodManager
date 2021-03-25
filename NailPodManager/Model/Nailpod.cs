﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace NailPodManager.Model
{
    public partial class Nailpod
    {
        [JsonProperty("machine_id")]
        public int MachineId { get; set; }

        [JsonProperty("mac_addr")]
        public string MacAddr { get; set; }

        [JsonProperty("ip_addr")]
        public string IpAddr { get; set; }

        [JsonProperty("card_reader_sn")]
        public string CardReaderSn { get; set; }

        [JsonProperty("epson_printer_sn")]
        public string EpsonPrinterSn { get; set; }

        [JsonProperty("receipt_printer_sn")]
        public string ReceiptPrinterSn { get; set; }

        [JsonProperty("cpu")]
        public string Cpu { get; set; }

        [JsonProperty("hdd")]
        public string Hdd { get; set; }

        [JsonProperty("ram")]
        public string Ram { get; set; }

        [JsonProperty("usb_yn")]
        public string UsbYn { get; set; }

        [JsonProperty("scanner_yn")]
        public string ScannerYn { get; set; }

        [JsonProperty("machine_status")]
        public string MachineStatus { get; set; }

        [JsonProperty("mf_loc")]
        public string MfLoc { get; set; }

        [JsonProperty("mf_dt")]
        public DateTimeOffset? MfDt { get; set; }

        [JsonProperty("use_yn")]
        public string UseYn { get; set; }

        [JsonProperty("del_yn")]
        public string DelYn { get; set; }

        [JsonProperty("reg_dt")]
        public DateTimeOffset? RegDt { get; set; }

        [JsonProperty("upd_dt")]
        public DateTimeOffset? UpdDt { get; set; }
    }

    public partial class Nailpod
    {
        public static Nailpod[] FromJson(string json) => JsonConvert.DeserializeObject<Nailpod[]>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Nailpod[] self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
