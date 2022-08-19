using iMessengerCoreAPI.DataLayer.Models;

namespace iMessengerCoreAPI.DataLayer.Interfaces
{
    public interface IRGDialogsRepository
    {
        Task<Guid> GetDialogByClientsID(IEnumerable<Guid> guids);
    }
}
