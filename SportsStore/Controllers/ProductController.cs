﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class ProductController:Controller
    {
        public IProductRepository repository;
        public int PageSize = 4;
        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }
        public ViewResult List(int productPage = 1)
        {
            //return View(repository.products.OrderBy(p => p.ProductID)
            //    .Skip(PageSize * (productPage - 1))
            //    .Take(PageSize));
            return View(new ProductsListViewModel {
                Products = repository.products.OrderBy(p => p.ProductID)
                    .Skip((productPage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo {
                    CurrentPage = productPage,
                    ItemsPerPage= PageSize,
                    TotalItems=repository.products.Count()
                }
            });
        }
    }
}