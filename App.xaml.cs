using ScriptObjectLoader.Views;
using Prism.Ioc;
using System.Windows;
using ScriptObjectLoader.ScriptLoader;
using ScriptObjectLoader.ScriptLoader.Python;

namespace ScriptObjectLoader
{
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IScriptLoader, PythonScriptLoader>();
        }
    }
}
