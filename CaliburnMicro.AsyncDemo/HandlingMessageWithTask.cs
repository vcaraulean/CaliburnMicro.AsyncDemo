using System.Threading.Tasks;
using Caliburn.Micro;

namespace CaliburnMicro.AsyncDemo
{
	public class Message
	{
		string Payload { get; set; }
	}

	public class HandlingMessageWithTask : IHandleWithTask<Message>
	{
		public Task Handle(Message message)
		{
			return Task.Delay(3000);
		}
	}
}