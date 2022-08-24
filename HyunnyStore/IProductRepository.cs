using System.Collections.Generic;
using System;
using HyunnyStore.Models;

namespace HyunnyStore
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts();
        //View Product
        public Product GetProduct(int id);
        //Update Product
        public void UpdateProduct(Product product);
        //Create Product
        public void InsertProduct(Product productToInsert);
        public IEnumerable<Category> GetCategories();
        public Product AssignCategory();
        //Delete Product
        public void DeleteProduct(Product product);
        //Search Product
        public IEnumerable<Product> GetSearchedProducts(string SearchProduct);

    }

}
