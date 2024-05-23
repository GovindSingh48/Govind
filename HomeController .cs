using Microsoft.AspNetCore.Mvc.ModelBinding;
using TestApiCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Data;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http;
using System.Data.SqlClient;
using System.Collections.Generic;
//using Microsoft.Data.SqlClient;
using System.Data.Common;
using System.Xml.Linq;
using Microsoft.Practices.EnterpriseLibrary.Data.Properties;
using System.Data.Entity;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Net.Mail;
using System.Drawing;
using static TestApiCore.TestApiController;
//using Microsoft.Data.SqlClient;
using static TestApiCore.Controllers.ItemsController;
using Microsoft.AspNetCore.Authentication;

namespace TestApiCore
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
