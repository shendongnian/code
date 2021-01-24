    [HttpGet("{id}")]
    public async Task<IActionResult> GetDepatment(int id, bool includeProducts = false) {
        var dept = await _deptInfoRepository.GetDepartmentWithOrWithoutProductsAsync(id, includeComputers);
        if (dept == null) {
            return BadRequest();
        }
        if (includeProducts) {
            var depResult =  new DepartmentDto() { deptId = dept.deptId, deptName = dept.deptName };
            foreach (var department in dept.Products) {
                depResult.Products.Add(new ProductDto() { 
                    productId = department.productId, 
                    deptId = department.deptId, 
                    ProductName = department.ProductName 
                });
            } 
            return Ok(depResult);
        }
        var departmentWithoutProductResult = new DepartmentsWithoutProductsDto() { DeptId = dept.deptId, DeptName = dept.DeptName};
        return Ok(departmentWithoutProductResult);
    }
