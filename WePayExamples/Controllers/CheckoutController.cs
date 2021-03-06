﻿using System.Web.Mvc;
using WePay;
using WePay.Infrastructure;
using WePay.Entities;
using WePay.Account;
using WePay.Checkout;
using WePay.CreditCard;
using WePay.Entities.Structure;

namespace Controllers
{
    [RouteArea("Account", AreaPrefix = "account")]
    [Route("{action=index}")]
    public class CheckoutController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Get()
        {
            long temp;
            long? accountId = null;
            var accessToken = Request.Form["accessToken"];
            if (long.TryParse(Request.Form["AccountId"], out temp)) accountId = temp;

            var wePayAccountService = new WePay.WePayAccountrService(accessToken);
            var wePayAccount = wePayAccountService.Get(new AccountArguments { AccountId = accountId });

            return View(wePayAccount);
        }

        public ActionResult Find()
        {

                return View(true);
        }
    }
}