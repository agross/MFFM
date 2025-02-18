using Mffm.Contracts;
using System.Windows.Input;

namespace Mffm.Core.ControlBindings;

internal class ButtonBinding : IControlBinding
{
  public bool Bind(Control control, IFormModel formModel)
  {
    if (control is not Button button) { return false; }

    //button.DataBindings.Add(new Binding(nameof(button.CommandParameter), formModel, null, true, DataSourceUpdateMode.Never));
    //button.DataBindings.Add(new Binding(nameof(button.Command), formModel, control.Name, true, DataSourceUpdateMode.OnPropertyChanged));

    var command = formModel.GetType().GetProperty(control.Name).GetValue(formModel) as ICommand;

    EventHandler click = (sender, args) => command.Execute(formModel);
    button.Click += click;

    EventHandler canExecute = (sender, args) => button.Enabled = command.CanExecute(formModel);
    command.CanExecuteChanged += canExecute;

    var form = button.FindForm();

    EventHandler formShown = (sender, args) => canExecute(sender, args);
    form.Shown += formShown;

    FormClosedEventHandler formClosed = null!;
    formClosed = (sender, args) =>
    {
      button.Click -= click;
      command.CanExecuteChanged -= canExecute;
      form.Shown -= formShown;

      form.FormClosed -= formClosed;
    };

    form.FormClosed += formClosed;
    return true;
  }
}