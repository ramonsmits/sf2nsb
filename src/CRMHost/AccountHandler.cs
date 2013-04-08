using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messages;

namespace Handlers
{
	using NServiceBus;

	public class AccountHandler : IMessageHandler<SaveAccountCommand>
	{
		public IBus Bus { get; set; }
		
		public void Handle(SaveAccountCommand message)
		{
			// TODO: Do some validation logic here and persist the account data from the message.
			Bus.Publish<AccountSavedEvent>(e =>
				{
					e.Id = message.Id;
					e.Name = message.Name;
					e.Website = message.Website;
					e.ModifedAt = DateTime.UtcNow;
				});
		}
	}
}
