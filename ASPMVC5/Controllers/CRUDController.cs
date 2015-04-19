using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPMVC5.Models;
namespace ASPMVC5.Controllers
{
    public class CRUDController : Controller
    {
        FabricsEntities1 db = new FabricsEntities1();
        // GET: CRUD
        public ActionResult Index(string keyword, int limit = 10)
        {
            //var db = new FabricsEntities1();
            //var data = db.Product;
            //var data = db.Product.Where(p => p.ProductName.StartsWith("C") && (p.Price >= 5 || p.Price <= 10));
            //var data = db.Product.ToList();
            //var data = db.Product.Where(p => p.ProductName.StartsWith("C"));
            //if (!string.IsNullOrEmpty(keyword))
            //{
            //     data = data.SqlQuery<Product>("Select Top " + limit + " From Product Where ProductName like @p", keyword + "%").AsQueryable();
            //    ViewBag.keyword = keyword;
            //}
             //var data = db.Product.Where(p => p.ProductName.StartsWith("C"));
            //var data = db.Product.AsQueryable();

            //if (!String.IsNullOrEmpty(keyword))
            //{
            //    data = data.Where(p => p.ProductName.StartsWith(keyword));
            //}

            //data = data.Take(limit);

            var data = db.Database.SqlQuery<Product>("SELECT TOP " + limit + " * FROM dbo.Product WHERE ProductName like @p0", keyword + "%").AsQueryable();
            ViewBag.keyword = keyword;
            //注意SP程式的型別<解決方式model去修改SP的傳回的型別>從模型瀏覽器去選擇實體型別            
            //var data = db.SP_QueryClient().AsQueryable();
            return View(data);
        }

        // GET: CRUD/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CRUD/Create
        public ActionResult Create()
        {            
            return View();
        }
        public ActionResult bactUpdate()
        {
            var data = db.Product.Where(p => p.ProductName.StartsWith("C"));
            foreach (var item in data)
            {
                item.Price = item.Price * 2;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // POST: CRUD/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            //try
            //{
                Product pro = new Product();
                pro.ProductName = collection["ProductName"];
                pro.Price = Convert.ToDecimal(collection["Price"]);
                pro.Active = true;
                pro.Stock = Convert.ToDecimal(collection["Stock"]);
                // TODO: Add insert logic here
                db.Product.Add(pro);
                db.SaveChanges();
                return RedirectToAction("Index");
            //}
            //catch
            //{
                //return View();
            //}
        }

        // GET: CRUD/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CRUD/Edit/5
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

        // GET: CRUD/Delete/5
        public ActionResult Delete(int id)
        {
            var clientdata = db.Client.Find(id);
            var order = clientdata.Order.ToList();
            foreach (var item in order)
            {
                //刪除多筆用RemoveRange
                db.OrderLine.RemoveRange(item.OrderLine.ToList());
            }
            db.Order.RemoveRange(order);
            //刪除一筆用Remove
            db.Client.Remove(clientdata);
            
            db.SaveChanges();
            return RedirectToAction("Index", "Clients");
            
            
        }

        // POST: CRUD/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
