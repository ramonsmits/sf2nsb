using Autofac;
using NServiceBus;
using Receiver;

namespace SalesForceAdapterHost
{
	public class EndpointConfig : IConfigureThisEndpoint, AsA_Server, IWantToRunAtStartup
	{
		public static IContainer Container;

		public void Run()
		{
			var builder = new ContainerBuilder();
			builder.RegisterType<ContactNotificationService>();
			Container = builder.Build();

			Configure.Instance.AutofacBuilder(Container);
		}

		public void Stop()
		{
		}
	}
}