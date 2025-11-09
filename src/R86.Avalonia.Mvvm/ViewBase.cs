using Avalonia.Controls;

namespace R86.Avalonia.Mvvm;

public abstract partial class ViewBase<T> : UserControl where T : ViewModelBase
{
    protected T ViewModel => (T)this.DataContext!;
    protected ViewBase()
    {
        DataContext = HostedApplicationUtils.GetViewModel<T>();
    }

    static ViewBase()
    {
        if (!Design.IsDesignMode)
        {
            LoadedEvent.AddClassHandler<ViewBase<T>>((view, _) => view.ViewModel.OnLoaded());
            UnloadedEvent.AddClassHandler<ViewBase<T>>((view, _) => view.ViewModel.OnUnloaded());
        }
    }
}
