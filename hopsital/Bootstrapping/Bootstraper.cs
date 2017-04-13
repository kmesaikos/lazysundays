using System;
using System.Collections.Generic;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace Hopsital.Bootstrapping
{
	public class Bootstrapper
	{
		private static IContainer _container;

		public static void Configure(params Registry[] registries)
		{
			_container?.Dispose();

			_container = new Container(x =>
			{
				foreach (var registry in registries)
				{
					x.AddRegistry(registry);
				}
			});
		}
		public static object GetInstance(Type type)
		{
			return _container.GetInstance(type);
		}

		public IEnumerable<T> GetAll<T>()
		{
			return _container.GetAllInstances<T>();
		}
	}
}