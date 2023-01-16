namespace DAL;
using BOL;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
public class DBManager
{
    public static List<Product> GetAllProducts(){
        List<Product> products = new List<Product>();
        products.Add(new Product(1,"iPhone 9","Apple","An apple mobile which is nothing like apple",50999,"smartphones",94));
        products.Add(new Product(2,"iPhone X","Apple","SIM-Free, Model A19211 6.5-inch Super Retina HD display with OLED technology A12 Bionic chip with ...",72999,"smartphones",83));
        products.Add(new Product(3,"Samsung Universe 9","Samsung","Samsung's new variant which goes beyond Galaxy to the Universe",10999,"smartphones",104));
        products.Add(new Product(4,"OPPOF19","OPPO","OPPO F19 is officially announced on April 2021.",17999,"smartphones",124));
        products.Add(new Product(5,"Huawei P30 9","Huawei","Huawei’s re-badged P30 Pro New Edition was officially unveiled yesterday in Germany and now the device has made its way to the UK.",12999,"smartphones",94));
        products.Add(new Product(6,"MacBook Pro","Apple","MacBook Pro 2021 with mini-LED display may launch between September, November",80999,"laptops",54));
        products.Add(new Product(7,"Samsung Galaxy Book S","Samsung","Samsung Galaxy Book S (2020) Laptop With Intel Lakefield Chip, 8GB of RAM Launched",60999,"laptops",94));
        return products;
    }

    public static List<Product> GetAllProductsFromFile(){ 
        string path = @"D:\Practical\dotnetPractical\DotNet\Day10\ECom\Product.json";
      
            if(File.Exists(path)){
                string jsonString=File.ReadAllText(path);
                List<Product> allProducts=JsonSerializer.Deserialize<List<Product>>(jsonString);
            return allProducts ;
            }
            else
            {
                return GetAllProducts();
            }  
    }
}
