using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Partial
{
    public partial class Product
    {
        public enum CategoryStatus
        {
            All = 0,
            IntroductionCooker,
            Gas
        }
        public enum PriceStatus
        {
            All = 0,
            Max3, //sp co gia max 3 trieu
            Min3, //sp co gia min 3 trieu
        }
        public enum SortStatus
        {
            All = 0,
            SortNew,
            SortPrice
        }
        public ProductDTO CopyObjectProduct()
        {
            var productDTO = new ProductDTO();
            ObjectUtil.CopyPropertiesTo(this, productDTO);
            return productDTO;
        }
    }
    public class GridProduct
    {
        public int CategoryStatus { get; set; }
        public int Pagesize { get; set; }
        public int CurrentPage { get; set; }
        public int PriceStatus { get; set; }
        public int SortStatus { get; set; }
    }
    public class JsonResultProduct
    {
        public object[] list { get; set; }
        
    }
    public class ProductDTO
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string MetaTitle { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Price { get; set; }
    }
    
}
