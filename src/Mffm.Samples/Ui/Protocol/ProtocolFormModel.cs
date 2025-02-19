using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Mffm.Commands;
using Mffm.Contracts;

namespace Mffm.Samples.Ui.Protocol;

public class ProtocolFormModel : INotifyPropertyChanged, IHandle<LogMessage>, IFormModel
{
    private readonly CloseFormCommand _closeFormCommand;

    private string _log = string.Empty;

    public ProtocolFormModel(CloseFormCommand closeFormCommand, IEventAggregator eventAggregator)
    {
        _closeFormCommand = closeFormCommand ?? throw new ArgumentNullException(nameof(closeFormCommand));

        eventAggregator.Subscribe(this);
    }

    public ICommand CloseWindow => _closeFormCommand;

    public string Log
    {
        get;
        set;
    }

    public Task HandleAsync(LogMessage message, CancellationToken cancellationToken)
    {
        Log = string.Join(Environment.NewLine, message.Message, Log);
        return Task.CompletedTask;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}