using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SCM_DataLayer.DataContext;
using SCM_DataLayer.DataEntity;
using SCM_ApplicationLayer.ApplicationImplementation;

namespace SCM_Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductImplementation ProductImp = new ProductImplementation();

        // GET: Products
        public ActionResult Index()
        {
            var products = ProductImp.GetProduct();
            return View(products);
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = ProductImp.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {

        
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Weight,Price")] Product product)
        {
            if (ModelState.IsValid)
            {

                ProductImp.AddProduct(product);
                return RedirectToAction("Index");
            }

        
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = ProductImp.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
         
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Weight,Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                ProductImp.UpdateProduct(product);
                return RedirectToAction("Index");
            }
     ;
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = ProductImp.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = ProductImp.Find(id);
            ProductImp.RemoveProduct(product);
           
            return RedirectToAction("Index");
        }

    }
}
