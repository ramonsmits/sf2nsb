using System;

namespace Messages
{
	public interface ContactSavedEvent
	{
		string Id { get; set; }
		string AccountId { get; set; }
		DateTime DateOfBirth { get; set; }
		DateTime CreatedAt { get; set; }
		DateTime ModifiedAt { get; set; }
	}
}
