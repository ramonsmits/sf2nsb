using System;

namespace Messages
{
	public interface AccountSavedEvent
	{
		DateTime ModifedAt { get; set; }
		string Website { get; set; }
		string Name { get; set; }
		string Id { get; set; }
		int Revision { get; set; }
	}
}