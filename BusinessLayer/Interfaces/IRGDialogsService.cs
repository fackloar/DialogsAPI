namespace iMessengerCoreAPI.BusinessLayer.Interfaces
{
    public interface IRGDialogsService
    {
        Task<Guid> GetDialogByIds(IEnumerable<Guid> ids);
    }
}
