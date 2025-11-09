using Avalonia;
using Avalonia.Controls;
using Microsoft.Extensions.DependencyInjection;
using R86.Avalonia.Hosting;

namespace R86.Avalonia.Mvvm;

internal static class HostedApplicationUtils
{
    public static T GetViewModel<T>() where T : ViewModelBase
    {
        // In design mode the user should use design data context
        if (Design.IsDesignMode)
            return null!;

        _app ??= GetAppInstance();

        return _app.Services.GetRequiredService<T>();
    }

    static HostedApplication? _app;

    static HostedApplication GetAppInstance()
    {
        if (Application.Current is not HostedApplication app)
        {
            throw new InvalidOperationException("Your application class must be derived from HostedApplication<`> class");
        }
        return app;
    }
}
