using ShopTesAmerica.Models;
using ShopTesAmerica.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopTesAmerica.Controllers
{
    public class ProductoController : Controller
    {
        readonly private ProductoRepository repository;
        public ProductoController()
        {
            repository = new ProductoRepository();
        }

        // GET: Producto
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetProductos()
        {
            List<Producto> productos = repository.GetProductos(); // Llama al método GetVendedores del repositorio.
            return Json(productos, JsonRequestBehavior.AllowGet);
        }

        // POST: Producto/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Producto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
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
