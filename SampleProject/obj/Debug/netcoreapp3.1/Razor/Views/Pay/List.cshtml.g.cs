#pragma checksum "c:\Users\Neati\Desktop\SampleGet\SampleProject\Views\Pay\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fdd5a09f78ed97f1d2c2b6d6337f0fa8d05c2d40"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pay_List), @"mvc.1.0.view", @"/Views/Pay/List.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "c:\Users\Neati\Desktop\SampleGet\SampleProject\Views\_ViewImports.cshtml"
using SampleProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "c:\Users\Neati\Desktop\SampleGet\SampleProject\Views\_ViewImports.cshtml"
using SampleProject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fdd5a09f78ed97f1d2c2b6d6337f0fa8d05c2d40", @"/Views/Pay/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7547ae200e22a29bcae05ee832a90868ebf4ba26", @"/Views/_ViewImports.cshtml")]
    public class Views_Pay_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!-- Data list view starts -->\r\n<section id=\"data-thumb-view\" class=\"data-thumb-view-header\">\r\n");
#nullable restore
#line 3 "c:\Users\Neati\Desktop\SampleGet\SampleProject\Views\Pay\List.cshtml"
   if (ViewBag.msg !=null) 
					{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t<p class=\"alert alert-warning text-center\">");
#nullable restore
#line 5 "c:\Users\Neati\Desktop\SampleGet\SampleProject\Views\Pay\List.cshtml"
                                                              Write(ViewBag.msg);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 6 "c:\Users\Neati\Desktop\SampleGet\SampleProject\Views\Pay\List.cshtml"
					}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"	<div class=""card-header"">
						<h4 class=""card-title"">اعتبارسنجی چندین نقشی</h4>
					</div>
  <!-- dataTable starts -->
  <div class=""table-responsive"">
    <table class=""table data-thumb-view Aroco-table"">
      <thead>
        <tr>
          <th></th>
          <th>ردیف</th>
          <th>نام و نام خانوادگی</th>
          <th> آدرس ایمیل </th>
          <th>تلفن</th>
          <th>تاریخ</th>
          <th> مبلغ </th>
          <th>عملیات </th>
          <th>اقدام</th>
        </tr>
      </thead>
      <tbody>
");
#nullable restore
#line 27 "c:\Users\Neati\Desktop\SampleGet\SampleProject\Views\Pay\List.cshtml"
         if (ViewBag.list !=null)
        {
            int i=1;
       
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "c:\Users\Neati\Desktop\SampleGet\SampleProject\Views\Pay\List.cshtml"
         foreach (var item in ViewBag.list )
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("          <tr>\r\n          <td></td>\r\n          <td class=\"product-name\"> ");
#nullable restore
#line 35 "c:\Users\Neati\Desktop\SampleGet\SampleProject\Views\Pay\List.cshtml"
                               Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n          <td class=\"product-category\">");
#nullable restore
#line 36 "c:\Users\Neati\Desktop\SampleGet\SampleProject\Views\Pay\List.cshtml"
                                  Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n          <td class=\"product-category\">");
#nullable restore
#line 37 "c:\Users\Neati\Desktop\SampleGet\SampleProject\Views\Pay\List.cshtml"
                                  Write(item.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n          <td class=\"product-category\">");
#nullable restore
#line 38 "c:\Users\Neati\Desktop\SampleGet\SampleProject\Views\Pay\List.cshtml"
                                  Write(item.Tel);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n          <td class=\"product-price\">");
#nullable restore
#line 39 "c:\Users\Neati\Desktop\SampleGet\SampleProject\Views\Pay\List.cshtml"
                               Write(item.Amonnt);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n          <td class=\"product-price\">");
#nullable restore
#line 40 "c:\Users\Neati\Desktop\SampleGet\SampleProject\Views\Pay\List.cshtml"
                               Write(item.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n          <td class=\"product-price\">");
#nullable restore
#line 41 "c:\Users\Neati\Desktop\SampleGet\SampleProject\Views\Pay\List.cshtml"
                               Write(item.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                         \r\n          <td class=\"product-action\">\r\n\r\n           <a");
            BeginWriteAttribute("href", " href=\"", 1376, "\"", 1402, 2);
            WriteAttributeValue("", 1383, "/home/edit/", 1383, 11, true);
#nullable restore
#line 45 "c:\Users\Neati\Desktop\SampleGet\SampleProject\Views\Pay\List.cshtml"
WriteAttributeValue("", 1394, item.Id, 1394, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"feather icon-edit\"></i></a>\r\n\r\n            <a onclick=\"return confirm(\'آیا از حذف اطلاعات مورد نظر اطمینان دارید؟\')\"");
            BeginWriteAttribute("href", " href=\"", 1530, "\"", 1555, 2);
            WriteAttributeValue("", 1537, "/home/del/", 1537, 10, true);
#nullable restore
#line 47 "c:\Users\Neati\Desktop\SampleGet\SampleProject\Views\Pay\List.cshtml"
WriteAttributeValue("", 1547, item.Id, 1547, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"feather icon-trash\"></i></a>\r\n         \r\n          </td>\r\n        </tr> \r\n");
#nullable restore
#line 51 "c:\Users\Neati\Desktop\SampleGet\SampleProject\Views\Pay\List.cshtml"
        i++; 
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 52 "c:\Users\Neati\Desktop\SampleGet\SampleProject\Views\Pay\List.cshtml"
         
         }

#line default
#line hidden
#nullable disable
            WriteLiteral("      \r\n\r\n      </tbody>\r\n    </table>\r\n  </div>\r\n  <!-- dataTable ends -->\r\n\r\n</section>\r\n<!-- Data list view end -->");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
