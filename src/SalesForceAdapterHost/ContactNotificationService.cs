using System.ServiceModel;
using System.ServiceModel.Activation;

using NServiceBus;

namespace Receiver
{
	using Messages;

	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
	[ServiceBehavior(TransactionIsolationLevel = System.Transactions.IsolationLevel.Serializable)]
	public class ContactNotificationService : NotificationPort
	{
		private readonly IBus bus;

		private static readonly notificationsResponse1 ResultOk = new notificationsResponse1
		{
			notificationsResponse = new notificationsResponse
			{
				Ack = true
			}
		};

		public ContactNotificationService(IBus bus)
		{
			this.bus = bus;
		}

		[OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
		public notificationsResponse1 notifications(notificationsRequest request)
		{
			foreach (var notificationItem in request.notifications.Notification)
			{
				Send(Convert(notificationItem.sObject));
			}

			return ResultOk;
		}

		private void Send(SaveContactCommand cmd)
		{
			bus.Send(cmd);
		}

		private SaveContactCommand Convert(global::Contact contact)
		{
			return new SaveContactCommand
			{
				Id = contact.Id,
				AccountId = contact.AccountId,
				Email = contact.Email,
				CreatedAt = contact.CreatedDate.Value,
				ModifiedAt = contact.SystemModstamp.Value
			};
		}
	}
}