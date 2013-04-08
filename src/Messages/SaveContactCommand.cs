using System;

namespace Messages
{
	public class SaveContactCommand
	{
		public string Id { get; set; }
		public string AccountId { get; set; }
		public string Email { get; set; }
		public DateTime DateOfBirth { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime ModifiedAt { get; set; }
	}
}
