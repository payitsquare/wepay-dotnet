﻿using Newtonsoft.Json;

namespace WePay.Entities.Rbits
{
    /// <summary>
    /// https://stage.wepay.com/developer/reference/rbit_types#review_uri
    /// </summary>
    public class RbitOtherWebContent : WepayRbitBase
    {
        [JsonProperty("uri")]
        public string Uri { get; set; }

    }
}
