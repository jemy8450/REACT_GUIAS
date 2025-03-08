using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using reatBackend.Models;
using reatBackend.Repository;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProfesorController : ControllerBase
    {
        private ProfesorDAO _proDao = new ProfesorDAO();
        // Se crea un endPoint con el metodo http post
        [HttpPost("autentificacion")]

        public string loginProfesor([FromBody] Profesor prof)
        {
            var prof1 = _proDao.login(prof.Usuario, prof.Pass);
            if (prof1 != null)
            {
                return prof1.Usuario;
            }
            return "Elemento no encontrado";
        }
    }
}
