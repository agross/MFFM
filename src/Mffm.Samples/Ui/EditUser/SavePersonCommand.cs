using System.Windows.Input;

namespace Mffm.Samples.Ui.EditUser;

public class SavePersonCommand : Contracts.ICanChangeMyCanExecuteState
{
  public bool CanExecute(object? parameter)
  {
    if (parameter is not EditFormModel model) return false;

    var can = model.Firstname.Length > 3;
    return can;
  }

  public void Execute(object? parameter)
  {
    if (parameter is not EditFormModel model) return;

    // Logic to save the person
  }

  public event EventHandler? CanExecuteChanged;


  public void MaybeCanExecuteChanged()
  {
    CanExecuteChanged?.Invoke(this, EventArgs.Empty);
  }
}