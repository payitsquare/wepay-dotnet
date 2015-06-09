﻿using WePay.Entities;
using WePay.Infrastructure;
using WePay.Services;
using WePay.User;

namespace WePay
{
    public class WePayUserService : WepayService
    {
        public WePayUserService(string accessToken = null, long? clientId = null, string ClientSecret = null) : base(accessToken, clientId, ClientSecret) { }

        public WePayUserService(string accessToken = null) : base(accessToken) { }

        public virtual WePayUser Get()
        {
            var response = Requestor.PostStringBearer(Urls.User, AccessToken);

            return Mapper<WePayUser>.MapFromJson(response);
        }

        public virtual WePayUser Modify(UserModifyArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.UserModify, AccessToken, parameters);

            return Mapper<WePayUser>.MapFromJson(response);
        }

        public virtual WePayUserRegisterd Register(UserRegisterArguments arguments)
        {
            arguments.ClientId = arguments.ClientId.Equals(null) ? (ClientId == null ? WePayConfiguration.GetClientId() : ClientId) : arguments.ClientId;
            arguments.ClientSecret = string.IsNullOrWhiteSpace(arguments.ClientSecret) ? (string.IsNullOrWhiteSpace(ClientSecret) ? WePayConfiguration.GetClientSecret() : ClientSecret) : arguments.ClientSecret;

            if(string.IsNullOrWhiteSpace(arguments.Scope)){
                arguments.Scope = "collect_payments,manage_accounts,manage_subscriptions,preapprove_payments,send_money,view_user";
            }
             
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostString(Urls.UserRegister, parameters);

            return Mapper<WePayUserRegisterd>.MapFromJson(response);
        }

        public virtual WePayUserSendConfirmation SendConfirmation(UserSendConfirmationArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.UserSendConfirmation, AccessToken, parameters);

            return Mapper<WePayUserSendConfirmation>.MapFromJson(response);
        }
    }
}
