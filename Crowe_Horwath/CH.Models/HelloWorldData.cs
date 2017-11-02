using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH.Models
{
    public class HelloWorldData
    {
        [JsonProperty("data")]

        public IEnumerable<HelloWorldRequest> data { get; set; }
    }
}
