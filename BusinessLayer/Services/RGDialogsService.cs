using iMessengerCoreAPI.BusinessLayer.Interfaces;
using iMessengerCoreAPI.DataLayer.Interfaces;

namespace iMessengerCoreAPI.BusinessLayer.Services
{
    public class RGDialogsService : IRGDialogsService
    {
        private IRGDialogsRepository _repository;

        public RGDialogsService(IRGDialogsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> GetDialogByIds(IEnumerable<Guid> ids)
        {
            var dialogGuid = await _repository.GetDialogByClientsID(ids);
            return dialogGuid;
        }
    }
}
