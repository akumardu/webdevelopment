using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Identity.Controllers
{
    public class SecretsController : Controller
    {
        [Authorize]
        public ContentResult Secret()
        {
            return new ContentResult() { Content = "This is a Secret" };
        }

        [AllowAnonymous]
        public ContentResult Overt()
        {
            return new ContentResult() { Content = "This is Overt" };
        }
    }
}