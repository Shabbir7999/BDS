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

		[HttpPost]
		public ActionResult Register(Donor donor)
		{
			// List<Donor> listofdonors;

			using (BDSContext db = new BDSContext())
			{
				donor.LastDonationDate = DateTime.MinValue;
				db.Donors.Add(donor);
				db.SaveChanges();
				//listofdonors = db.Donors.ToList();
			}



			return View();

		}

		[HttpGet]
		public ActionResult Admin()
		{
			return View();
		}



		[HttpPost]
		public ActionResult Admin(Admin admin)
		{
			//List<Admin> listofadmins;
			
			try
			{
				using (BDSContext db = new BDSContext())
				{
					//var admins = db.Admins;
					foreach (Admin a in db.Admins)
					{
						if (a.Username.Equals(admin.Username) && a.Password.Equals(admin.Password))
						{
							return RedirectToAction("AdminServices", "Home");
							
						}


					}
					return RedirectToAction("AdminNotFound", "Home");
				}

			}
			catch (Exception ex)
			{
				return RedirectToAction("ErrorPage", "Home");
			}



		}

		public ActionResult Contact()
		{
			return View();
		}
		public ActionResult About()
		{
			return View();
		}
		public ActionResult AdminServices()
		{
			return View();
		}

		[HttpGet]
		public ActionResult DeleteDonor()
		{

			return View();
		}


		[HttpPost]
		public ActionResult FindDeleteDonor(Donor obj)
		{
			using (BDSContext db = new BDSContext())
			{
				foreach (Donor d in db.Donors)
				{
					if (d.Email.Equals(obj.Email))
					{

						return View(d);

					}


				}

			}
			return View("ErrorPage", "Home");

		}


		[HttpPost]
		public ActionResult DeleteDonorData(Donor obj)
		{
			using (BDSContext db = new BDSContext())
			{
				db.Donors.Remove(obj);
				db.SaveChanges();

			}
			return RedirectToAction("AdminServices", "Home");


		}






		[HttpPost]
		public ActionResult ShowSearchDonorTable(string Bloodtype, string Residence)
		{
			List<Donor> listofdonors = new List<Donor>();
			try
			{
				using (BDSContext db = new BDSContext())
				{
					//var d_list = db.Donors.ToList();


					listofdonors = db.Donors.Where(x => x.Bloodtype.Equals(Bloodtype)).ToList();
				}
				return View(listofdonors);

			}
			catch (Exception ex)
			{
				return RedirectToAction("ErrorPage", "Home");
			}

			//return View();
		}

		[HttpGet]
		public ActionResult SearchDonor()
		{

			return View();

		}



		[HttpGet]
		public ActionResult UpdateDonor()
		{

			return View();
		}

		[HttpPost]
		public ActionResult FindDonor(Donor obj)
		{

			using (BDSContext db = new BDSContext())
			{
				foreach (Donor d in db.Donors)
				{
					if (d.Email.Equals(obj.Email))
					{
						return View(d);
					}
				}

			}
			return RedirectToAction("UpdateDonor", "Home");

		}
		//private bool IsDonationEligible(DateTime lastDonationDate)
		//{
			//return DateTime.Now >= lastDonationDate.AddMonths(3);
		//}


		public ActionResult Save(Donor obj)
		{
			using (BDSContext db = new BDSContext())
			{
				db.Donors.Update(obj);
				db.SaveChanges();

			}
			return RedirectToAction("AdminServices", "Home");
		}


		public ActionResult ErrorPage()
		{
			return View();
		}



	}
}
