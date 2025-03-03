using reatBackend.Repository;
using System;

AlumnoDAO alumnoDAO = new AlumnoDAO();

var alumno = alumnoDAO.SelectAll();

foreach (var item in alumno) 
{
    Console.WriteLine(item.Nombre);
}

Console.WriteLine("");

var selectById = alumnoDAO.GetById(1000);
Console.WriteLine(selectById?.Nombre);
