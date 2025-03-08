using reatBackend.Context;
using reatBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reatBackend.Repository
{
    public class CalificacionDao
    {
         
        public RegistroAlumno2_0Context _contexto = new RegistroAlumno2_0Context();

        #region Seleccionar_lista_caificaciones 
        public List<Calificacion> seleccion(int matriculaid)
        {

            var matricula = _contexto.Matriculas.Where(x => x.Id == matriculaid).ToList();
            ;
            try
            {
                if (matricula != null)
                {

                    var calificacion = _contexto.Calificacions.Where(x => x.Id == matriculaid).ToList();

                    return calificacion;
                }
                else
                {

                    return null;
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
                return null;
            }


        }
        #endregion
    }
}
