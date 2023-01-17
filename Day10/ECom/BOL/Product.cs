namespace BOL;
public class Product
{
    public int ProductId{get;set;}
    public string? Title{get;set;} 
    public string? Description{get;set;}
    public double Price{get;set;}
    public double DiscountPercentage{get;set;}
    public double Rating{get;set;}
    public int Stock{get;set;}
    public string? Brand{get;set;}
    public string? Category{get;set;}

    public Product(){}
    public Product(int id,string title,string desc,double price,double discount,double rating,int bal,string brand,string category){
    this.ProductId = id;
    this.Title = title;
    this.Description = desc;
    this.Price = price;
    this.DiscountPercentage = discount;
    this.Rating = rating;
    this.Stock = bal;
    this.Brand = brand;
    this.Category = category;
    }
    public Product(int id,string title,string brand,string desc,double price,string category,int bal){
    this.ProductId = id;
    this.Title = title;
    this.Brand = brand;
    this.Description = desc;
    this.Price = price;
    this.Category = category;
    this.Stock = bal;
    }
}
