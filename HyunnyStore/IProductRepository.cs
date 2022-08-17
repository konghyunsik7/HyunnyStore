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
    }

}
