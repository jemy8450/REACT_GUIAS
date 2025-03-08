using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using reatBackend.Models;
using reatBackend.Repository;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class CalificacionController : ControllerBase
    {
        private CalificacionDao _cdao = new CalificacionDao();

        #region lista de calificaciones
        [HttpGet("calificaciones")]

        public List<Calificacion> get(int idMatricula)
        {
            return _cdao.seleccion(idMatricula);
        }
    }
    #endregion
}
