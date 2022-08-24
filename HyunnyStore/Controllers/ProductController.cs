using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HyunnyStore.Models;
using Microsoft.AspNetCore.Mvc;


namespace HyunnyStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository repo;
 
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductController(IProductRepository repo, IWebHostEnvironment hostEnvironment)
        {
            this.repo = repo;
            this._hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            var products = repo.GetAllProducts();
            return View(products);
        }
        //View Products
        public IActionResult ViewProduct(int id)
        {
            var product = repo.GetProduct(id);
            return View(product);
        }
        //Update Products
        public IActionResult UpdateProduct(int id)
        {
            Product prod = repo.GetProduct(id);
            if (prod == null)
            {
                return View("ProductNotFound");
            }
            return View(prod);
        }
        //Create Product
        public IActionResult UpdateProductToDatabase(Product product)
        {
            repo.UpdateProduct(product);

            return RedirectToAction("ViewProduct", new { id = product.ProductID });
        }
        public IActionResult InsertProduct()
        {
            var prod = repo.AssignCategory();
            return View(prod);
        }
        public IActionResult InsertProductToDatabase(Product productToInsert)
        {
            repo.InsertProduct(productToInsert);
            return RedirectToAction("Index");
        }
 
        public IActionResult DeleteProduct(Product product) // DeleteProduct
        {

            repo.DeleteProduct(product);
            var relativePath = "/images/" + product.ProductID + ".png";
            string wwwRootPath = _hostEnvironment.WebRootPath;
            var absolutePath = wwwRootPath + relativePath;
            if (System.IO.File.Exists(absolutePath))
            {
                System.IO.File.Delete(absolutePath);
            }
            return RedirectToAction("Index");
        }
        public IActionResult ProductSearch(string SearchProduct)
        {
            var filteredProducts = repo.GetSearchedProducts(SearchProduct);
            return View(filteredProducts);
        }
    }
    }
