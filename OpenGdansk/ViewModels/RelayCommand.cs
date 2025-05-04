using System.Windows.Input;

namespace OpenGdansk.ViewModels;

public class RelayCommand(Action execute, Func<bool> canExecute) : ICommand
{
    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter) => canExecute();

    public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

    public void Execute(object? parameter)
    {
        execute.Invoke();
    }

}