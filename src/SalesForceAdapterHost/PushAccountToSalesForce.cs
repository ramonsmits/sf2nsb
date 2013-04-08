using System;
using Messages;
using NServiceBus;

namespace Handlers
{
	public class PushAccountToSalesForce : IMessageHandler<AccountSavedEvent>
	{
		public SalesForceApi.SforceService Client { get; set; }

		public void Handle(AccountSavedEvent message)
		{
			var customer = new SalesForceApi.Account
			{
				AccountNumber = message.Id,
				Name = message.Name,
				Website = message.Website,
			};

			// This will update when a record exist with a matching 'AccountId' field else it will insert.
			var result = Client.upsert("AccountId", new SalesForceApi.sObject[] { customer });

			if (!result[0].success) throw new InvalidOperationException("Failed to create account object.");
		}
	}
}
