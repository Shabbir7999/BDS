using BDS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;



namespace BDS.Controllers
{
	public class HomeController : Controller
	{


		public ActionResult Index() //home page
		{
			return View();
		}
		[HttpGet]
		public ActionResult Register()
		{
			return View();
		}
	}
}