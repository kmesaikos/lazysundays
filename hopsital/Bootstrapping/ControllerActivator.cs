using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Hopsital.Bootstrapping
{
	public class ControllerActivator : IHttpControllerActivator
	{
		public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
		{
			var controller = Bootstrapper.GetInstance(controllerType) as IHttpController;
			return controller;
		}
	}
}