﻿using WePay.Checkout;
using WePay.Entities;
using WePay.Infrastructure;
using WePay.Services;

namespace WePay
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/checkout
    /// </summary>
    public class WePayCheckoutService : WepayService
    {
        public WePayCheckoutService(string accessToken = null) : base(accessToken) { }

        public virtual WePayCheckout Get(CheckoutArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.Checkout, AccessToken, parameters);

            return Mapper<WePayCheckout>.MapFromJson(response);
        }

        public virtual WePayCheckout[] Find(CheckoutFindArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.CheckoutFind, AccessToken, parameters);

            return Mapper<WePayCheckout[]>.MapFromJson(response);
        }

        public virtual WePayCheckout Create(CheckoutCreateArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.CheckoutCreate, AccessToken, parameters);

            return Mapper<WePayCheckout>.MapFromJson(response);
        }

        public virtual WePayCheckoutState Cancel(CheckoutCancelArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.CheckoutCancel, AccessToken, parameters);

            return Mapper<WePayCheckoutState>.MapFromJson(response);
        }

        public virtual WePayCheckoutState Refund(CheckoutCancelArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.CheckoutRefund, AccessToken, parameters);

            return Mapper<WePayCheckoutState>.MapFromJson(response);
        }

        public virtual WePayCheckoutState Capture(CheckoutCancelArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.CheckoutCapture, AccessToken, parameters);

            return Mapper<WePayCheckoutState>.MapFromJson(response);
        }

        public virtual WePayCheckout Modify(CheckoutCreateArguments arguments)
        {
            var parameters = ParameterBuilder.ApplyParameters(arguments);
            var response = Requestor.PostStringBearer(Urls.CheckoutModify, AccessToken, parameters);

            return Mapper<WePayCheckout>.MapFromJson(response);
        }
    }
}
