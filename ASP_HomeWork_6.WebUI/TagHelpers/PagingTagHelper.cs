﻿using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace ASP_HomeWork_6.WebUI.TagHelpers
{
    [HtmlTargetElement("product-list-pager")]
    public class PagingTagHelper :TagHelper
    {
        [HtmlAttributeName("page-size")]
        public int PageSize { get; set; }
        [HtmlAttributeName("page-count")]
        public int PageCount { get; set; }
        [HtmlAttributeName("current-category")]
        public int CurrentCategory { get; set; }
        [HtmlAttributeName("current-page")]
        public int CurrentPage { get; set; } 
        [HtmlAttributeName("current-sort")]
        public int CurrentSort { get; set; }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "section";

            var sb = new StringBuilder();
            if (PageCount > 1)
            {
                sb.Append("<ul class='pagination'>");

                if (CurrentPage > 1)
                {

                sb.AppendFormat("<li class='{0}'>", "page-item");
                sb.AppendFormat("<a  class='page-link' href='/product/index?page={0}&category={1}&sort={2}'> << </a>",
                    CurrentPage - 1, CurrentCategory, CurrentSort);
                sb.Append("</li>");
                }

                for (int i = 1; i <= PageCount; i++)
                {
                    sb.AppendFormat("<li class='{0}'>", (i == CurrentPage) ? "page-item active" : "page-item");
                    sb.AppendFormat("<a  class='page-link' href='/product/index?page={0}&category={1}&sort={2}'> {3} </a>",
                        i, CurrentCategory, CurrentSort, i);
                    sb.Append("</li>");
                }

                if (CurrentPage != PageCount)
                {

                sb.AppendFormat("<li class='{0}'>", "page-item");
                sb.AppendFormat("<a  class='page-link' href='/product/index?page={0}&category={1}&sort={2}'> >> </a>",
                    CurrentPage + 1, CurrentCategory, CurrentSort);
                sb.Append("</li>");
                }


                sb.Append("</ul>");
            }

            output.Content.SetHtmlContent(sb.ToString());
        }
    }
}
