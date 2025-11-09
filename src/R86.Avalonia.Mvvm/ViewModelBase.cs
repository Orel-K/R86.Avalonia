using CommunityToolkit.Mvvm.ComponentModel;

namespace R86.Avalonia.Mvvm;

public abstract class ViewModelBase : ObservableObject
{
    public virtual void OnLoaded() { }
    public virtual void OnUnloaded() { }
}
