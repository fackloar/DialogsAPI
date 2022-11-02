using iMessengerCoreAPI.API.Responses;
using iMessengerCoreAPI.BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iMessengerCoreAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RGDialogsController : ControllerBase
    {
        private IRGDialogsService _RGDialogsService;

        public RGDialogsController(IRGDialogsService rGDialogsService)
        {
            _RGDialogsService = rGDialogsService;
        }

        /// <summary>
        /// Получает guid диалога, в котором участвовали все пользователи, guid которых были переданы.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// GET clientsId?guids=4b6a6b9a-2303-402a-9970-6e71f4a47151&amp;guids=c72e5cb5-d6b4-4c0c-9992-d7ae1c53a820
        /// </remarks>
        /// <param name="guids">guid пользователя, диалог с которым необходимо найти</param>
        /// <returns>Guid диалога; пустой если диалог с заданными пользователями не найден</returns>
        /// 
        [HttpGet("/clientsId/")]
        public async Task<ActionResult<GuidResponse>> GetDialogByIds([FromQuery] IEnumerable<Guid> guids)
        {
            var dialog = await _RGDialogsService.GetDialogByIds(guids);
            return Ok(dialog);
        }
    }
}
