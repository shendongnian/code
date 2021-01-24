    Category obj = new Category();
    obj.SubCategories = new List<SubCategory>();
    int categoryId = 0;
    obj.CategoryId = categoryId++;
    Console.Write("Enter Category Name : ");
    obj.CategoryName = Console.ReadLine();
    
    do
    {
        Console.WriteLine("want to add SubCategory ----(Y/N)");
        string loop = Console.ReadLine();
        if (loop == "Y" || loop == "y")
        {
            SubCategory sub = new SubCategory();
            sub.Products = new List<Product>();
            sub.CategoryId = obj.CategoryId;
            sub.SubCategoryId = subcategoryId++;
            Console.Write("EnterSub Category Name : ");
            sub.SubCategoryName = Console.ReadLine();
            do
            {
                Console.WriteLine("want to add product ----(Y/N)");
                string loop1 = Console.ReadLine();
                if(loop1 == "y" || loop1 == "Y")
                {
                    Product product = new Product();
                    Console.Write("Name :");
                    product.ProductId = productId++;
                    product.ProdictName = Console.ReadLine();
                    Console.Write("Price :");
                    product.ProductPrice = Convert.ToDouble(Console.ReadLine());
                    product.SubCategoryId = sub.SubCategoryId;
                    sub.Products.Add(product);
                }
                else { break; }
                      
            } while (true);
            obj.SubCategories.Add(sub);
        }
        else { break; }
    } while (true);
    
    categories.Add(obj);
