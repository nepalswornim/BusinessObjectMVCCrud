using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using BusinessLogicLayer.Entity;

namespace BusinessObjectMVCCRUD.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        BLLProduct blp = new BLLProduct();
        public ActionResult Index()
        {
            List<ProductDetails> lst = blp.GetAllUser();
            return View(lst);
        }
        [HttpGet]
        public ActionResult Create() {



            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductDetails pd) {

            if (ModelState.IsValid)
            {
                blp.CreateUser(pd);
                return RedirectToAction("Index");
                
            }
            






            return View();
        }
        [HttpGet]
        public ActionResult Edit( int id){
            List<ProductDetails> pdlst = new List<ProductDetails>();

            var products = blp.GetAllUserById(id);
            var p = products.ToList();
            ProductDetails pd = new ProductDetails();
            pd.ProductId=p.
          
         
            return View();
    
    }
    }
}
