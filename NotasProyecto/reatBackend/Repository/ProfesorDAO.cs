using reatBackend.Context;
using reatBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reatBackend.Repository
{
    public class ProfesorDAO
    {
        #region context
        public RegistroAlumno2_0Context context = new RegistroAlumno2_0Context();
        #endregion

        #region GetById
        public Profesor login(string usuario, string pass)
        {
            var prof = context.Profesors.Where(
                p => p.Usuario == usuario
                && p.Pass == pass).FirstOrDefault();
            return prof;
        }
        #endregion
    }
}