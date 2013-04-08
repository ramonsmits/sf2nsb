using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using Autofac.Integration.Wcf;
using log4net;
using NServiceBus;
using Receiver;

namespace SalesForceAdapterHost
{
	/// <remarks>Based on : https://code.google.com/p/autofac/wiki/WcfIntegration</remarks>
	public class SalesForceReceiverHost : IWantToRunAtStartup
	{
		private readonly ILog Log = LogManager.GetLogger(typeof(SalesForceReceiverHost));

		private ServiceHost host;

		public void Run()
		{
			var address = new Uri("http://localhost:8181/contact");
			host = new ServiceHost(typeof(ContactNotificationService), address);
			host.AddServiceEndpoint(typeof(NotificationPort), new BasicHttpBinding(), string.Empty);
			host.AddDependencyInjectionBehavior<ContactNotificationService>(EndpointConfig.Container); // Autofac extension
			host.Description.Behaviors.Add(new ServiceMetadataBehavior { HttpGetEnabled = true, HttpGetUrl = address });

			Log.Info("Starting");
			host.Open();
			Log.Info("Started");
		}

		public void Stop()
		{
			Log.Info("Stopping");
			host.Close();
			Log.Info("Stopped");
		}
	}
}
