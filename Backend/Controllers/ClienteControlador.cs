using Backend.modelos;
using Microsoft.AspNetCore.Mvc;
using Backend.Utils;
using Microsoft.Extensions.Hosting;
using System.Drawing.Printing;
using System.Diagnostics;

namespace Backend.Controllers
{
    [ApiController]
    [Route("laapi")]
    public class ClienteControlador : ControllerBase
    {
        [HttpGet]
        [Route("listaempleados")]
        public dynamic listarClientes()
        {
            BaseDatos db = new BaseDatos("localhost", "laarcourier", "root", "mysql");
            List <EmpleadoOficina> empleadosOficinas = db.GetEmpleadosOficinas();
            Trace.WriteLine("Se ejecuto");
            return empleadosOficinas;
        }


        [HttpGet]
        [Route("listaoficinas")]
        public dynamic listarOficinas()
        {
            BaseDatos db = new BaseDatos("localhost", "laarcourier", "root", "mysql");
            List<Oficinas> oficinas = db.GetOficinas();
            Trace.WriteLine("Se ejecuto");
            return oficinas;
        }

        [HttpPost]
        [Route("guardarEmpleado")]
        public dynamic guardarEmpleado(EmpleadoNuevo nuevoEmpleado) {
            BaseDatos db = new BaseDatos("localhost", "laarcourier", "root", "mysql");
            db.RegistrarEmpleado(nuevoEmpleado);
            return new {
                succes = true,
                message = "Registrado",
                nuevoEmpleado = nuevoEmpleado
            };
        }

    } 
}
