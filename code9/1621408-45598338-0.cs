    using Domain.Abstract;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    
    namespace WebUI.Controllers
    {
        public class BooksController : Controller
        {
            private IBookRepository repository;
            
    public BooksController():this(new BookRepository())
            {
    
            }
            public BooksController(IBookRepository repo)
            {
                repository = repo;
            }
    
            public ViewResult List()
            {
                return View(repository.Books);
            }
        }
    }
