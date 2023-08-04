using ShopTesAmerica.Models;
using ShopTesAmerica.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopTesAmerica.Controllers
{
    public class VendedorController : Controller
    {
        readonly private VendedorRepository repository;
        public VendedorController()
        {
            repository = new VendedorRepository();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetVendedores()
        {
            List<Vendedor> vendedores = repository.GetVendedores(); // Llama al método GetVendedores del repositorio.
            return Json(vendedores, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Create(Vendedor collection)
        {   
            try
            {
                repository.Agregar(collection);
                var resp = new { error = false };
                return Json(resp, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                var resp = new { error = true };
                return Json(resp, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Edit(Vendedor collection)
        {
            try
            {
                repository.Editar(collection);
                var resp = new { error = false };
                return Json(resp, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                var resp = new { error = true };
                return Json(resp, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
