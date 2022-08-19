using iMessengerCoreAPI.DataLayer.Interfaces;
using iMessengerCoreAPI.DataLayer.Models;

namespace iMessengerCoreAPI.DataLayer.Repositories
{
    public class RGDialogsRepository : IRGDialogsRepository
    {

        List<RGDialogsClients> _dialogs;

        public RGDialogsRepository()
        {
            RGDialogsClients rGDialogsClients = new RGDialogsClients();
            _dialogs = rGDialogsClients.Init();
        }

        public async Task<Guid> GetDialogByClientsID(IEnumerable<Guid> guids)
        {
            var groupedDialogs = _dialogs.GroupBy(d => d.IDRGDialog);
            var dialogToReturn = new Guid();

            foreach (var groupedDialog in groupedDialogs)
            {
                if (groupedDialog.Count() == guids.Count())
                {
                    var listedGuidsOfGroupedDialog = groupedDialog.Select(i => i.IDClient).ToList();
                    var firstSet = new HashSet<Guid>(listedGuidsOfGroupedDialog);
                    var secondSet = new HashSet<Guid>(guids);

                    bool isEqual = Enumerable.SequenceEqual(firstSet.OrderBy(g => g), secondSet.OrderBy(g => g));

                    if (isEqual)
                    {
                        var gropedDialogsList = groupedDialog.ToList();
                        dialogToReturn = gropedDialogsList.FirstOrDefault().IDRGDialog;
                    }
                }
            }

            return dialogToReturn;
        }
    }
}
