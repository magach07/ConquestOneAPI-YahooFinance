using ConquestOne.Domain.Entities;

namespace ConquestOne.Application.Receivers.Interfaces
{
    public interface IReceiver<in T, out W>
    where T : List<PETR4Entity>
    where W : State
    {
        W Action (T command);
    }
}