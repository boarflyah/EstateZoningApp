using System.Windows.Input;

namespace EstateZoningApp.Commands;

public class BaseCommand : ICommand
{
    public event EventHandler CanExecuteChanged;

    public bool CanExecute(object parameter) => throw new NotImplementedException();
    public void Execute(object parameter) => throw new NotImplementedException();
}