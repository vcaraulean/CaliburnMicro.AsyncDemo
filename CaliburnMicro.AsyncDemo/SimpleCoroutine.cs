using System;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace CaliburnMicro.AsyncDemo
{
	public class SimpleCoroutine : IResult
	{
		public async void Execute(ActionExecutionContext context)
		{
			// simulating work
			await Task.Delay(6000);
			Completed(this, new ResultCompletionEventArgs());
		}

		public event EventHandler<ResultCompletionEventArgs> Completed = delegate { };
	}
}