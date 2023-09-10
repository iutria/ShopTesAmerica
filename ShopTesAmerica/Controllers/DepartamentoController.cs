using ShopTesAmerica.Models;
using ShopTesAmerica.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopTesAmerica.Controllers
{
    public class DepartamentoController : Controller
    {
        readonly private DepartamentoRepository repository;
        public DepartamentoController()
        {
            repository = new DepartamentoRepository();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetDepartamentos()
        {
            List<Departamento> departamentos = repository.GetDepartamentos();
            return Json(departamentos, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AgregarDepartamento(Departamento collection)
        {
            try
            {
                repository.AgregarDepartamento(collection);
                var resp = new { error = false };
                return Json(resp, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                var resp = new { error = true };
                return Json(resp, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult AgregarCiudad(Ciudad collection)
        {
            try
            {
                repository.AgregarCiudad(collection);
                var resp = new { error = false };
                return Json(resp, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                var resp = new { error = true };
                return Json(resp, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult EditarDepartamento(Departamento collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
