using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin
{
    public class APIResponseRoot
    {
        [JsonProperty(PropertyName = "list")]
        public List<APIResponse> list { get; set; }
    }
}
