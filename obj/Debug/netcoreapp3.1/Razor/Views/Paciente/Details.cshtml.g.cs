#pragma checksum "C:\Users\chapa\Documents\Turnos\Views\Paciente\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a296615b1e9548aef14006ee186265159474a7e1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Paciente_Details), @"mvc.1.0.view", @"/Views/Paciente/Details.cshtml")]
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
#line 1 "C:\Users\chapa\Documents\Turnos\Views\_ViewImports.cshtml"
using Turnos;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\chapa\Documents\Turnos\Views\_ViewImports.cshtml"
using Turnos.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a296615b1e9548aef14006ee186265159474a7e1", @"/Views/Paciente/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5b9c7a7584d54ef9e045a44f17b50f6dc5da374", @"/Views/_ViewImports.cshtml")]
    public class Views_Paciente_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Turnos.Models.Paciente>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h4>Paciente</h4>\r\n\r\n<div>\r\n    <dl>\r\n        <dt>\r\n            ");
#nullable restore
#line 8 "C:\Users\chapa\Documents\Turnos\Views\Paciente\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 11 "C:\Users\chapa\Documents\Turnos\Views\Paciente\Details.cshtml"
       Write(Html.DisplayFor(model => model.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 14 "C:\Users\chapa\Documents\Turnos\Views\Paciente\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Apellido));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 17 "C:\Users\chapa\Documents\Turnos\Views\Paciente\Details.cshtml"
       Write(Html.DisplayFor(model => model.Apellido));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <dt>\r\n            ");
#nullable restore
#line 19 "C:\Users\chapa\Documents\Turnos\Views\Paciente\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Dni));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 22 "C:\Users\chapa\Documents\Turnos\Views\Paciente\Details.cshtml"
       Write(Html.DisplayFor(model => model.Dni));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 25 "C:\Users\chapa\Documents\Turnos\Views\Paciente\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Direccion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 28 "C:\Users\chapa\Documents\Turnos\Views\Paciente\Details.cshtml"
       Write(Html.DisplayFor(model => model.Direccion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 31 "C:\Users\chapa\Documents\Turnos\Views\Paciente\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Telefono));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 34 "C:\Users\chapa\Documents\Turnos\Views\Paciente\Details.cshtml"
       Write(Html.DisplayFor(model => model.Telefono));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 37 "C:\Users\chapa\Documents\Turnos\Views\Paciente\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 40 "C:\Users\chapa\Documents\Turnos\Views\Paciente\Details.cshtml"
       Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n\r\n</div>\r\n\r\n<div>\r\n    ");
#nullable restore
#line 47 "C:\Users\chapa\Documents\Turnos\Views\Paciente\Details.cshtml"
Write(Html.ActionLink("Editar", "Edit", new { id = Model.IdPaciente }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n    ");
#nullable restore
#line 48 "C:\Users\chapa\Documents\Turnos\Views\Paciente\Details.cshtml"
Write(Html.ActionLink("Volver", "Index"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Turnos.Models.Paciente> Html { get; private set; }
    }
}
#pragma warning restore 1591
