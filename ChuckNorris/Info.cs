using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChuckNorris
{
    public class Info
    {
        [JsonProperty("categories")]
        public IList<string> Categories { get; set; }
        [JsonProperty("created_at")]
        public DateTime Created_at { get; set; }
        [JsonProperty("icon_url")]
        public string Icon_url { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("updated_at")]
        public DateTime Updated_at { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }

        //public IList<string> categories { get; set; }
        //public string created_at { get; set; }
        //public string icon_url { get; set; }
        //public string id { get; set; }
        //public string updated_at { get; set; }
        //public string url { get; set; }
        //public string value { get; set; }
    }
}
