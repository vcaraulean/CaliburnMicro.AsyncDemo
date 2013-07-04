using System;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace CaliburnMicro.AsyncDemo
{
	public class ShellViewModel : Screen, IShell
	{
		public ShellViewModel()
		{
			LogMessages = new BindableCollection<LogEntry>();
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

		public async Task RunTask1Async()
		{
			Log("RunTask1Async - starting a 4 second task");
			await Task.Delay(4000);
			Log("RunTask1Async completed");
		}

		public async Task WrapIResultInTaskAsync()
		{
			Log("WrapIResultInTaskAsync - executing coroutine");
			await new SimpleCoroutine().ExecuteAsync();
			Log("WrapIResultInTaskAsync completed");
		}

		private void Log(string message)
		{
			LogMessages.Add(new LogEntry(message));
		}

		public IObservableCollection<LogEntry> LogMessages { get; protected set; }
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