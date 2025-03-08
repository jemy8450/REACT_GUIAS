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
        #region AlumnoDaoInstancia
        private AlumnoDAO _dao = new AlumnoDAO();
        #endregion
        #region endPonitAlumnoProfesor
        [HttpGet("alumnoProfesor")]
        public List<AlumnoProfesor> GetAlumnoProfesor(string usuario)
        {
            return _dao.alumnoProfesors(usuario);
        }

        #endregion
        #region SelectByID
        [HttpGet("alumno")]
        public Alumno seletById(int id)
        {
            var alumno = _dao.GetById(id);
            return alumno;
        }
        #endregion
        #region ActualizarDatos

        [HttpPut("alumno")]
        public bool actualizarAlumno([FromBody] Alumno alumno)
        {
            return _dao.update(alumno.Id, alumno);
        }
        #endregion
        #region AlumnoMatricula
        [HttpPost("alumno")]
        public bool insertarMatricula([FromBody] Alumno alumno, int idAsignatura)
        {
            return _dao.InsertarMatricula(alumno, idAsignatura);
        }
        #endregion
        #region deleteAlumno
        [HttpDelete("alumno")]

        public bool eleminarAlumno(int id)
        {
            return _dao.eliminarAlumno(id);
        }
        #endregion
    }
}

