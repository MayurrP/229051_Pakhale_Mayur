namespace BLL;
using System.Collections.Generic;
using BOL;
using DAL;
public class CatalogManager
{
    public List<Product> GetAllProductsFromFile(){
        List<Product> allProducts = new List<Product>();
        allProducts=DBManager.GetAllProductsFromFile();
        return allProducts;
    }

     public Product GetProduct(int id){
      List<Product> allProducts=GetAllProductsFromFile();
      
       Product foundProduct=allProducts.Find((product)=>product.ProductId ==id);
      return foundProduct ;
    }
}