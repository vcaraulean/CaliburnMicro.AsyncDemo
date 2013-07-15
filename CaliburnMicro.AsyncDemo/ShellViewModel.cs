using System;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace CaliburnMicro.AsyncDemo
{
	public class ShellViewModel : Screen, IShell
	{
		private readonly IEventAggregator eventAggregator;

		public ShellViewModel(IEventAggregator eventAggregator, MessageHandler messageHandler)
		{
			this.eventAggregator = eventAggregator;
			LogMessages = new BindableCollection<LogEntry>();

			ViewAttached += OnViewAttachedEventHandler;
		}

		private async void OnViewAttachedEventHandler(object sender, ViewAttachedEventArgs args)
		{
			Log("OnViewAttachedEventHandler- starting a 1 second task");
			await Task.Delay(1000);
			Log("OnViewAttachedEventHandler completed");
		}

		protected override async void OnActivate()
		{
			Log("OnActivate - starting a 8 seconds task");
			await Task.Delay(8000);
			Log("OnActivate completed");
		}

		protected override async void OnInitialize()
		{
			Log("OnInitialize - starting a 7 seconds task");
			await Task.Delay(7000);
			Log("OnInitialize completed");
		}

		protected override async void OnViewAttached(object view, object context)
		{
			Log("OnViewAttached - starting a 3 seconds task");
			await Task.Delay(3000);
			Log("OnViewAttached completed");
		}

		protected override async void OnViewLoaded(object view)
		{
			Log("OnViewLoaded - starting a 5 seconds task");
			await Task.Delay(5000);
			Log("OnViewLoaded completed");
		}

		public async void RunTask1Async()
		{
			Log("RunTask1Async - starting a 4 second task");
			await Task.Delay(4000);
			Log("RunTask1Async completed");
		}

		public async void WrapIResultInTaskAsync()
		{
			Log("WrapIResultInTaskAsync - executing coroutine");
			await new SimpleCoroutine().ExecuteAsync();
			Log("WrapIResultInTaskAsync completed");
		}

		public void PublishEventAndHandleAsync()
		{
			eventAggregator.Publish(new Message());
		}

		public static void Log(string message)
		{
			Console.WriteLine(message);
			LogMessages.Add(new LogEntry(message));
		}

		public static IObservableCollection<LogEntry> LogMessages { get; protected set; }
	}

	public class LogEntry
	{
		public LogEntry(string message)
		{
			Message = message;
			TimeStamp = DateTime.Now;
		}

		public string Message { get; private set; }
		public DateTime TimeStamp { get; private set; }
	}
}