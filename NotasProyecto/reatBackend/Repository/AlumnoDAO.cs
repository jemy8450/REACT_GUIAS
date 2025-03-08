using reatBackend.Context;
using reatBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reatBackend.Repository
{
    public class AlumnoDAO
    {
        public RegistroAlumno2_0Context contexto = new RegistroAlumno2_0Context();

        //selectAll
        public List<Alumno> SelectAll()
        {
            var alumno = contexto.Alumnos.ToList<Alumno>();
            return alumno;

        }
        //selectById
        public Alumno? GetById(int id)
        {
            var alumno = contexto.Alumnos.Where(x => x.Id == id).FirstOrDefault();
            return alumno == null ? null : alumno;
        }

        //Insert
        public bool insertarAlumno(Alumno alumno)
        {
            try
            {
                var alum = new Alumno
                {
                    Direccion = alumno.Direccion,
                    Edad = alumno.Edad,
                    Email = alumno.Email,
                    Dni = alumno.Dni,
                    Nombre = alumno.Nombre
                };
                //añaddimos al contexto de dataset que representa la base de datos el metodo add
                contexto.Alumnos.Add(alum);
                //este elemnto en si no nos guardara los datos para ello debemos utilizar el metodo save
                contexto.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //update alumno
        public bool update(int id, Alumno actualizar)
        {
            try
            {
                var alumnoUpdate = GetById(id);

                if (alumnoUpdate == null)
                {
                    Console.WriteLine("Alumno es null");
                    return false;
                }

                alumnoUpdate.Direccion = actualizar.Direccion;
                alumnoUpdate.Dni = actualizar.Dni;
                alumnoUpdate.Nombre = actualizar.Nombre;
                alumnoUpdate.Email = actualizar.Email;

                contexto.Alumnos.Update(alumnoUpdate);
                contexto.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return false;
            }
        }

        //Delete
        public bool deleteAlumno(int id)
        {
            var borrar = GetById(id);
            try
            {
                if (borrar == null)
                {
                    return false;

                }
                else
                {
                    contexto.Alumnos.Remove(borrar);
                    contexto.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return false;
            }
        }

        //LeftJoin
        public List<AlumnoAsignatura> SelectAlumAsig()
        {
            var consulta = from a in contexto.Alumnos
                           join m in contexto.Matriculas on a.Id equals m.AlumnoId
                           join asig in contexto.Asignaturas on m.AsignaturaId equals asig.Id
                           select new AlumnoAsignatura
                           {

                               nombreAlumno = a.Nombre,
                               nombreAsignatura = asig.Nombre

                           };

            return consulta.ToList();
        }


        public List<AlumnoProfesor> alumnoProfesors(string nombreProfesor)
        {
            var listadoALumno = from a in contexto.Alumnos
                                join m in contexto.Matriculas on a.Id equals m.AlumnoId
                                join asig in contexto.Asignaturas on m.AsignaturaId equals asig.Id
                                where asig.Profesor == nombreProfesor
                                select new AlumnoProfesor
                                {
                                    Id = a.Id,
                                    Dni = a.Dni,
                                    Nombre = a.Nombre,
                                    Direccion = a.Direccion,
                                    Edad = a.Edad,
                                    Email = a.Email,
                                    asignatura = asig.Nombre
                                };

            return listadoALumno.ToList();
        }


    }
}
