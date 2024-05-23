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
	public class TestApiController : Controller
	{
		public class EMP
		{
			public int Id { get; set; }
			public string FirstName { get; set; }
			public string LastName { get; set; }

		}
		public static List<EMP> emp = new List<EMP>()
		{
		new EMP() { Id = 1,FirstName = "Doe1",LastName = "John1" },
		new EMP() { Id = 2,FirstName = "First",LastName = "Last" },
		new EMP() { Id = 3,FirstName = "First3",LastName = "Last3" },
		};

		public IActionResult TestGetApi()
		{
			var a = from q in emp
						//where q.Id == 1
					orderby q.Id
					select q;
			// or return Ok(emp);
			return Ok(a);
		}

		public IActionResult TestPostApi([FromBody] EMP E)
		{
			if (E.Id != 0)
			{
				emp.Add(E);
				return Ok(emp);
			}
			else if (E.Id == 0)
			{
				return Json("Parameter Errore");
			}
			else
			{
				//return BadRequest();
				return Json("Error - Id Not Found");
			}
		}

		public IActionResult TestUpdate([FromBody] EMP Parameter)
		{
			if (Parameter.Id != 0)
			{
				EMP e = emp.Find(a => a.Id == Parameter.Id);
				e.Id = Parameter.Id;
				e.FirstName = Parameter.FirstName;
				e.LastName = Parameter.LastName;

				return Ok(emp);
			}
			else if (Parameter.Id == 0)
			{
				return Json("Parameter Errore");
			}
			else
			{
				//return BadRequest();
				return Json("Error - Id Not Found");
			}
		}

		public IActionResult TestDelete(int Id)
		{
			var deletedemp = emp.Find(a => a.Id == Id);
			if (Id > 0)
			{
				emp.Remove(deletedemp);
				return Ok(emp);
			}
			else
			{ return Ok("Error"); }
		}

		[HttpPost]
		public ActionResult TestApiNew(string First, string Last)
		{
			if (First != "")
			{
				EMP e = emp.Find(a => a.FirstName == First);
				e.FirstName = First;
			
				e.LastName = Last;

				return Ok(emp);
			}
			else if (First == "")
			{
				return Json("Parameter Errore");
			}
			else
			{
				//return BadRequest();
				return Json("Error - Id Not Found");
			}
		}
	}
}

