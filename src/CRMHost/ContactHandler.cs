using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messages;

using NServiceBus;

namespace Handlers
{

	public class ContactHandler : IMessageHandler<SaveContactCommand>
	{
		public IBus Bus { get; set; }
		public void Handle(SaveContactCommand message)
		{
			Bus.Publish<ContactSavedEvent>(
				e =>
					{
						e.Id = message.Id;
						e.AccountId = message.AccountId;
						e.DateOfBirth = message.DateOfBirth;
						e.CreatedAt = message.CreatedAt;
						e.ModifiedAt = message.ModifiedAt;
					});
		}
	}
}
