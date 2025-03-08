using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using reatBackend.Models;
using reatBackend.Repository;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private AlumnoDAO _dao = new AlumnoDAO();

        [HttpGet("alumnoProfesor")]

        public List<AlumnoProfesor> GetAlumnoProfesor(string usuario)
        {
            return _dao.alumnoProfesors(usuario);
        }

        //selectById
        [HttpGet("alumno")]

        public Alumno SelectById(int id)
        {
            var alumno = _dao.GetById(id);
            return alumno;
        }

        //actualizarDatos
        [HttpPut("alumno")]
        public bool actualizaAlumno([FromBody] Alumno alumno)
        {           
            return _dao.update(alumno.Id, alumno);
        }
    }   
}

