using System;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace CaliburnMicro.AsyncDemo
{
	public class SimpleCoroutine : IResult
	{
		public void Execute(ActionExecutionContext context)
		{
			// simulating work
			Task
				.Run(() => Task.Delay(6000))
				.ContinueWith(task => Completed(this, new ResultCompletionEventArgs()));
		}

		public event EventHandler<ResultCompletionEventArgs> Completed = delegate { };
	}
}