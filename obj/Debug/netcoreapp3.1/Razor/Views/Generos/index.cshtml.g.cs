#pragma checksum "/home/josimarg/git/animetflix/Views/Generos/index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "464ca3dde6e875683ace83fc921c02f5167ad0ea"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Generos_index), @"mvc.1.0.view", @"/Views/Generos/index.cshtml")]
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
#line 1 "/home/josimarg/git/animetflix/Views/_ViewImports.cshtml"
using animetflix;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/josimarg/git/animetflix/Views/_ViewImports.cshtml"
using animetflix.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "/home/josimarg/git/animetflix/Views/Generos/index.cshtml"
using animetflix.Models.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"464ca3dde6e875683ace83fc921c02f5167ad0ea", @"/Views/Generos/index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6433eb70e0528d6ad5f06073339e464f1a61581e", @"/Views/_ViewImports.cshtml")]
    public class Views_Generos_index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Genero>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<h1>Lista de generos</h1>
<div class=""form-group"">
    <a class=""btn btn-info"">Agregar Género</a>
</div>
<hr>
<div class=""row"">
    <div class=""col-md-6"">
        <table class=""table table-hover"">
            <thead>
                <tr>
                    <th></th>
                    <th>Nombre</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 19 "/home/josimarg/git/animetflix/Views/Generos/index.cshtml"
                 foreach (var genero in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\n                        <td>\n                            <a class=\"btn btn-success\">Editar</a>\n                            <a class=\"btn btn-danger\">Eliminar</a>\n                        </td>\n                        <td>");
#nullable restore
#line 26 "/home/josimarg/git/animetflix/Views/Generos/index.cshtml"
                       Write(genero.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    </tr>   \n");
#nullable restore
#line 28 "/home/josimarg/git/animetflix/Views/Generos/index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\n        </table>\n    </div>\n</div>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Genero>> Html { get; private set; }
    }
}
#pragma warning restore 1591
