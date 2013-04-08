using System;
using System.Configuration;

namespace SalesForceApi
{
	public static class SalesForceServiceFactory
	{
		const int Timeout = 60000;
		private static readonly Config Settings = ConfigurationManager.GetSection("SalesForceServiceFactoryConfig") as Config;

		public static SforceService Create()
		{
			if (Settings == null) throw new InvalidOperationException("Configuration section 'SalesForceServiceFactoryConfig' does not exist.");

			var svc = new SforceService { Timeout = Timeout };

			var loginResult = svc.login(Settings.Username, Settings.Password + Settings.SecurityToken);

			svc.Url = loginResult.serverUrl;
			svc.SessionHeaderValue = new SessionHeader { sessionId = loginResult.sessionId };

			return svc;
		}

		public class Config : ConfigurationSection
		{
			[ConfigurationProperty("username", IsRequired = true)]
			public string Username
			{
				get { return (string)this["username"]; }
			}

			[ConfigurationProperty("password", IsRequired = true)]
			public string Password
			{
				get { return (string)this["password"]; }
			}

			[ConfigurationProperty("securityToken", IsRequired = true)]
			public string SecurityToken
			{
				get { return (string)this["securityToken"]; }
			}
		}
	}
}
