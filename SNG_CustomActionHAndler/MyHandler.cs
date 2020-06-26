using Scriptngo.ExtensionInterfaces;
using System.Reflection;

namespace SNG_CustomActionHandler
{
  public class MyHandler : ICustomActionHandler
  {
    private bool _terminated = false;
    private ICustomActionHandlerProvider _provider = null;

    public ICustomActionHandlerProvider Provider => _provider;

    public bool IsTerminated() => _terminated;

    public string CodeBase => Assembly.GetExecutingAssembly().CodeBase;

    public bool DoCustomAction(IScriptExecutorBase Executor, DeviceConnectionInfo ConnectionInfo, out dynamic ActionResult, out bool ConnectionDropped, out bool BreakExecution)
    {
      ActionResult = "I was called";
      ConnectionDropped = false;
      BreakExecution = false;
      return true;
    }

    public string[] HandledCustomActions()
    {
      return new string[] { "MyID" };
    }

    public void HostUnreachable(IScriptExecutorBase Executor, DeviceConnectionInfo ConnectionInfo)
    {
      // Nothing to perform here for a basic implementation
    }

    public void Initialize(IScriptExecutorBase Executor)
    {
      _terminated = false;
    }

    public bool LoggingRequired()
    {
      return false;
    }

    public void RegisterProvider(ICustomActionHandlerProvider provider)
    {
      _provider = provider;
    }

    public void Terminate()
    {
      _terminated = true;
    }
  }
}
