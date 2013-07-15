using System.Threading.Tasks;
using Caliburn.Micro;

namespace CaliburnMicro.AsyncDemo
{
	public class Message { }

	public class MessageHandler : IHandleWithTask<Message>
	{
		public MessageHandler(IEventAggregator eventAggregator)
		{
			eventAggregator.Subscribe(this);
		}

		public async Task Handle(Message message)
		{
			ShellViewModel.Log("HandlingMessageWithTask - starting a 3 seconds task");
			await Task.Delay(3000);
			ShellViewModel.Log("HandlingMessageWithTask - completed");
		}
	}
}