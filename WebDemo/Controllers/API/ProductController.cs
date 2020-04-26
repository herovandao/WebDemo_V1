
using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static ClassLibrary.Product;

namespace WebDemo.Controllers.API
{
    public class ProductController : ApiController
    {
        [AcceptVerbs("POST","GET")]
        public IHttpActionResult GetProducts(GridProduct model)
        {
            using (WebDemoEntities db = new WebDemoEntities())
            {
                var products = db.Products.Where(x=>x.CategoryID == model.CategoryStatus);
                //lọc theo giá
                switch (model.PriceStatus)
                {
                    case (int)PriceStatus.Max3:
                        products = products.Where(x => x.Price <= 3000000);
                        break;
                    case (int)PriceStatus.Min3:
                        products = products.Where(x => x.Price > 3000000);
                        break;
                }
                //sắp xếp
                switch (model.SortStatus)
                {
                    case (int)SortStatus.SortNew:
                        products = products.OrderByDescending(x=>x.CreatedDate);
                        break;
                    case (int)SortStatus.SortPrice:
                        products = products.OrderByDescending(x => x.Price);
                        break;
                }
                //phân trang
                products = products.Skip(model.CurrentPage * model.Pagesize + 1).Take(model.Pagesize);
                JsonResultProduct json = new JsonResultProduct
                {
                    list = products.Select(x => x.CopyObjectProduct()).ToArray()
                };
                return Json(new { data = json });
            }
        }
    }
}
