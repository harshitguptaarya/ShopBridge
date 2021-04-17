#region Namespace

using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

#endregion


namespace ShopBridge.Models
{
    /// <summary>
    /// This class specifies the data transfer object proeprties 
    /// </summary>
    [Serializable]
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ResponseDto
    {
        public string Code { get; set; }

        public Data Data { get; set; }
    }

    [Serializable]
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class Data
    {
        public Response Response { get; set; }
    }

    [Serializable]
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class Response
    {
        public string ReasonCode { get; set; }

        public string ReasonText { get; set; }

        public string DataList { get; set; }

        public string Error { get; set; }
        
    }

}
