using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        //Instanciamiento de la capa de negocion
        public EmpleadoBL empleadoBL = new EmpleadoBL();
        public ProveedorBL proveedorBL = new ProveedorBL();
        public TipoZapatoBL tipoZapatoBL = new TipoZapatoBL();
        public CabeceraOrdenBL cabeceraOrdenBL = new CabeceraOrdenBL();
        public DetalleOrdenBL detalleOrdenBL = new DetalleOrdenBL();
        public DetalleOrden detalleDep;
        public DetalleOrden detalleCas;
        public DetalleOrden detalleFor;
        public CabeceraOrden cabeceraOrden;

        public ActionResult Index()
        {
            ViewBag.Empleados = empleadoBL.Listar();
            ViewBag.Proveedores = proveedorBL.Listar();
            ViewBag.TipoZapatos = tipoZapatoBL.Listar();
            return View();
        }

        public ActionResult Guardar()
        {
            var resp = "";
            if (Reglas())
            {
                resp = "Error: El total de zapatos tiene que tener un minimo de 10 o la cantidad de zapatos deportivos, casuales y formales no deben superar los 20, 40 y 100 respectivamente";
                ViewBag.Mensaje = resp;
                return View("/Views/Shared/_Mensaje.cshtml");
            }
            InstCabeceraOrden(ref cabeceraOrden, DateTime.Now, new string[] { "empleado", "proveedor", "TotalCan"});
            var cOrden = cabeceraOrdenBL.Registrar(cabeceraOrden);
            InstDetalleOrden(ref detalleDep, "IdZapDep", "CanDep", cOrden);
            InstDetalleOrden(ref detalleCas, "IdZapCas", "CanCas", cOrden);
            InstDetalleOrden(ref detalleFor, "IdZapFor", "CanFor", cOrden);
            if (detalleOrdenBL.Registrar(detalleDep) && detalleOrdenBL.Registrar(detalleCas) && detalleOrdenBL.Registrar(detalleFor))
            {
                resp = "Registrado correctamente";
            }
            else
            {
                resp = "Error: Ha ocurrido un error mientras se registraba los detalles";
            }

            ViewBag.Mensaje = resp;
            return View("/Views/Shared/_Mensaje.cshtml");
        }

        public ActionResult Show()
        {
            return View();
        }


        //Metodos para instanciamiento y validaciones
        public void InstDetalleOrden(ref DetalleOrden detalleOrden, string nameRequestId, string cantRequest, CabeceraOrden cOrden)
        {
            detalleOrden = new DetalleOrden
            {
                IdOrden = cOrden.IdOrden,
                IdTipoZapato = Convert.ToInt32(Request[nameRequestId]),
                Cantidad = Convert.ToInt32(Request[cantRequest])
            };
        }

        public void InstCabeceraOrden(ref CabeceraOrden cabeceraOrden, DateTime fechaIngreso, string[] datos)
        {
            cabeceraOrden = new CabeceraOrden
            {
                IdEmpleado = Convert.ToInt32(Request[datos[0]]),
                IdProveedor = Convert.ToInt32(Request[datos[1]]),
                FechaIngreso = fechaIngreso,
                TotalPares = Convert.ToInt32(Request[datos[2]])
            };
        }
        public Boolean Reglas()
        {
            if (Convert.ToInt32(Request["TotalCan"]) < 10) return true;
            if (Convert.ToInt32(Request["CanDep"]) > 20) return true;
            if (Convert.ToInt32(Request["CanCas"]) > 40) return true;
            if (Convert.ToInt32(Request["CanFor"]) > 100) return true;
            return false;
        }
    }
}