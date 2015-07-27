﻿using Newtonsoft.Json;
using WePay.Entities.Structure;

namespace WePay.Account
{
    public class AccountMembershipModifyArguments
    {
        /// <summary>
        /// https://www.wepay.com/developer/reference/account-membership#modify
        /// </summary>
        [JsonProperty("account_id", Required = Required.Always)]
        public long? AccountId { get; set; }

        [JsonProperty("member_access_token", Required = Required.Always)]
        public string MemberAccessToken { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("admin_context")]
        public WepayMembershipAdminContext AdminContext { get; set; }

        public string BatchUrl() { return "/account/membership/modify"; }
    }
}
