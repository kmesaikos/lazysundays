using System;
using System.Linq;
using System.Web;
using Hopsital.Models;

namespace hopsital.Services
{
	public class PatientsRepository
	{
		private const string CacheKey = "PatientsStore";

		public PatientsRepository()
		{
			var ctx = HttpContext.Current;
			if (ctx != null)
			{
				if (ctx.Cache[CacheKey] == null)
				{
					var patients = new Patient[]
					{
						new Patient
						{
							Id = 1,
							Name = "kostas",
							Condition = "crazy",
							ImageId = 11
						},

						new Patient
						{
							Id = 2,
							Name = "vaso",
							Condition = "crazyMore",
							ImageId = 22
						}
					};
					ctx.Cache[CacheKey] = patients;
				}
			}
		}

		public Patient[] GetAllPetients()
		{
			var ctx = HttpContext.Current;
			if (ctx != null)
			{
				return (Patient[]) ctx.Cache[CacheKey];
			}
			return new Patient[]
			{
				new Patient
				{
					Id = 0,
					Name = "PlaceHolder",
					Condition = "dont know",
					ImageId = 00
				}
				
			};
		}

		public bool SavePatient(Patient patient)
		{
			var ctx = HttpContext.Current;

			if (ctx != null)
			{
				try
				{
					var currentData = ((Patient[])ctx.Cache[CacheKey]).ToList();
					currentData.Add(patient);
					ctx.Cache[CacheKey] = currentData.ToArray();

					return true;
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.ToString());
					return false;
				}
			}
			return false;
		}
	}
}