    using System;  
    using System.Collections.Generic;  
    using System.Linq;  
    using System.Threading.Tasks;  
    using Microsoft.AspNetCore.Mvc;  
    using ExampleGrid.Models;  
    using System.Linq.Dynamic;  
    // For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860  
      
    namespace ExampleGrid.Controllers  
    {  
        public class DemoGridController : Controller  
        {  
            private DatabaseContext _context;  
      
            public DemoGridController(DatabaseContext context)  
            {  
                _context = context;  
            }  
            // GET: /<controller>/  
            public IActionResult ShowGrid()  
            {  
                return View();  
            }  
      
            public IActionResult LoadData()  
            {  
                try  
                {  
                    var draw = HttpContext.Request.Form["draw"].FirstOrDefault();  
                    // Skiping number of Rows count  
                    var start = Request.Form["start"].FirstOrDefault();  
                    // Paging Length 10,20  
                    var length = Request.Form["length"].FirstOrDefault();  
                    // Sort Column Name  
                    var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();  
                    // Sort Column Direction ( asc ,desc)  
                    var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();  
                    // Search Value from (Search box)  
                    var searchValue = Request.Form["search[value]"].FirstOrDefault();  
      
                    //Paging Size (10,20,50,100)  
                    int pageSize = length != null ? Convert.ToInt32(length) : 0;  
                    int skip = start != null ? Convert.ToInt32(start) : 0;  
                    int recordsTotal = 0;  
      
                    // Getting all Customer data  
                    var customerData = (from tempcustomer in _context.CustomerTB  
                                        select tempcustomer);  
      
                    //Sorting  
                    if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))  
                    {  
                        customerData = customerData.OrderBy(sortColumn + " " + sortColumnDirection);  
                    }  
                    //Search  
                    if (!string.IsNullOrEmpty(searchValue))  
                    {  
                        customerData = customerData.Where(m => m.Name == searchValue);  
                    }  
      
                    //total number of rows count   
                    recordsTotal = customerData.Count();  
                    //Paging   
                    var data = customerData.Skip(skip).Take(pageSize).ToList();  
                    //Returning Json Data  
                    return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });  
      
                }  
                catch (Exception)  
                {  
                    throw;  
                }  
      
            }  
        }  
    }  
