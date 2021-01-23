    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Security;
    namespace project.Models
    {
        public class Paging
    {
        private projectEntities db = new projectEntities();
        public string Pagination(int total, int page, int Take, int offset, string Controler, string View, string Params)
        {
            if (total > 0)
            {
                string c_url = HttpContext.Current.Request.Url.AbsoluteUri.ToLower();
                string URL = c_url.Substring(0, c_url.IndexOf(Controler.ToLower()));
                double rowPerPage = Take;
                if (Convert.ToDouble(total) < Take)
                {
                    rowPerPage = Convert.ToDouble(total);
                }
                int totalPage = Convert.ToInt16(Math.Ceiling(Convert.ToDouble(total) / rowPerPage));
                int current = page;
                int record = offset;
                int pageStart = Convert.ToInt16(Convert.ToDouble(current) - Convert.ToDouble(offset));
                int pageEnd = Convert.ToInt16(Convert.ToDouble(current) + Convert.ToDouble(offset));
                string numPage = "";
                if (totalPage < 1) return "";
                numPage += "<ul class='pagination'>";
                if (current > 1) numPage += "<li class='previous'><a href='" + URL + Controler + View + "?Page=" + (page - 1) + Params + "' aria-label='Previous'>&laquo;</a></li>";
                else numPage += "<li class='disabled'><a href='#' aria-label='Previous'><span aria-hidden='true'>&laquo;</span></a></li>";
                if (current > (offset + 1)) numPage += "<li><a href='" + URL + Controler + View + "?Page=1" + Params + "' name='page1'>1</a></li><li class='disabled spacing-dot'><a href='#'>...</a></li>";
                for (int i = 1; i <= totalPage; i++)
                {
                    if (pageStart <= i && pageEnd >= i)
                    {
                        if (i == current) numPage += "<li class='active'><a href='#'>" + i + " <span class='sr-only'>(current)</span></a></li>";
                        else numPage += "<li><a href='" + URL + Controler + View + "?Page=" + i + Params + "'>" + i + "</a></li>";
                    }
                }
                if (totalPage > pageEnd)
                {
                    record = offset;
                    numPage += "<li class='disabled spacing-dot'><a href='#'>...</a></li><li><a href='" + URL + Controler + View + "?Page=" + (totalPage) + Params + "'>" + totalPage + "</a></li>";
                }
                if (current < totalPage) numPage += "<li class='next'><a class='ui-bar-d' href='" + URL + Controler + View + "?Page=" + (page + 1) + Params + "'>&raquo;</a></li>";
                else numPage += "<li class='disabled'><a href='#' aria-label='Previous'><span aria-hidden='true'>&raquo;</span></a></li>";
                numPage += "</ul>";
                return numPage;
            }
            else
            {
                return "no records found";
            }
        }
    }
    }
