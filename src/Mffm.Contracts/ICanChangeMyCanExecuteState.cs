using System.Windows.Input;

namespace Mffm.Contracts
{
    public interface ICanChangeMyCanExecuteState : ICommand
    {
       public void MaybeCanExecuteChanged();
    }
}
