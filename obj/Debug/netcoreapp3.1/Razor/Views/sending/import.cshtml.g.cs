#pragma checksum "C:\Users\wspal\Desktop\project_final_6013532\Views\sending\import.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4f7d4ba7591cbedd5cbfc541102f6608debeb92c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_sending_import), @"mvc.1.0.view", @"/Views/sending/import.cshtml")]
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
#line 1 "C:\Users\wspal\Desktop\project_final_6013532\Views\_ViewImports.cshtml"
using project_final_6013532;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\wspal\Desktop\project_final_6013532\Views\_ViewImports.cshtml"
using project_final_6013532.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4f7d4ba7591cbedd5cbfc541102f6608debeb92c", @"/Views/sending/import.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"97dcc127ca7d9fc2ae146a509cc09e7fccae798c", @"/Views/_ViewImports.cshtml")]
    public class Views_sending_import : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<nav aria-label='breadcrumb'>
    <ol class='breadcrumb breadcrumb-arrow'>
        <li class='breadcrumb-item active' aria-current='page'>Import Reject-ATS file and send message</li>

    </ol>
</nav>
<div id='app1' v-cloak>

    <v-app>
        <v-main>
            <v-file-input label=""Click the paper clip to select the file"" v-model=""file1"">
            </v-file-input>
            <v-btn color=""blue darken-1"" class=""white--text"" ");
            WriteLiteral(@"@click=""upload"">
                import reject ATS
                <v-icon>mdi-import</v-icon>
            </v-btn><br><br>

            <!--do not forget to chagne this section-->
            This is the current database<br><br>
            <v-data-table :headers='headers' :items='records' class='elevation-1' />
            </v-data-table>
            <br><br><br>
            Message Format<br><br>
            <v-data-table :headers='headers2' :items='records' class='elevation-1'>
            </v-data-table><br>

            <v-btn color=""green darken-1"" class=""white--text"" ");
            WriteLiteral("@click=\"send_message\">\r\n                send message\r\n                <v-icon color=\"white\">\r\n                    mdi-message-text\r\n                </v-icon>\r\n            </v-btn>\r\n\r\n\r\n        </v-main>\r\n    </v-app>\r\n</div>\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
<script>
    var app;
    var component = {
        vuetify: new Vuetify(),
        el: '#app1',
        data: {
            records: [],
            file1: null,
            parameter: {},
            headers: [{
                        text: 'Client Ref no',
                        value: 'clientRef',
                        align: 'center',
                    },
                    {
                        text: 'Reference Code',
                        value: 'refer',
                        align: 'center',
                    },
                    {
                        text: 'Sending Bank',
                        value: 'sBank',
                        align: 'center',
                    },
                    {
                        text: 'Sending Bank no',
                        value: 'sBankNo',
                        align: 'center'
                    },
                    {
                        text: 'Receiving Bank',
                        value:");
                WriteLiteral(@" 'rBank',
                        align: 'center'
                    },
                    {
                        text: 'Receiving Bank No',
                        value: 'rBankNo',
                        align: 'center'
                    },
                    {
                        text: 'Amount',
                        value: 'num',
                        align: 'center'
                    },
                    {
                        text: 'Status Code',
                        value: 'statCode',
                        align: 'center'
                    },
                    {
                        text: 'Status Description',
                        value: 'stat',
                        align: 'center'
                    },

                ] //end of headers array
                ,
            headers2: [{
                        text: 'Client Ref no',
                        value: 'clientRef',
                        align: 'center',
              ");
                WriteLiteral(@"      },
                    {
                        text: 'Sending Bank',
                        value: 'sBank',
                        align: 'center',
                    },
                    {
                        text: 'Status Description',
                        value: 'stat',
                        align: 'center'
                    },
                    {
                        text: 'Amount',
                        value: 'num',
                        align: 'center'
                    },
                    {
                        text: 'MKT telephone',
                        value: 'tel',
                        align: 'center'
                    },
                ] //end of headers2 array
                ,
        } //end of data
        ,
        created() {
            this.records = ");
#nullable restore
#line 126 "C:\Users\wspal\Desktop\project_final_6013532\Views\sending\import.cshtml"
                      Write(Html.Raw(Json.Serialize(@ViewBag.records)));

#line default
#line hidden
#nullable disable
                WriteLiteral(@";
        },
        methods: {
            upload() {
                //to get the attach file in the v-input-file
                //and then make a request to the server
                var data = new FormData(); //this datatype is to submit the file to server
                //append is the function that take (<xx>,<NameFromVuejsData>)
                // xx = the name that will be encrypted and send it to server
                //it must match because it will be extracted later on in the server
                data.append(""file1"", this.file1);
                console.log(data);
                //make ajax
                var option = {
                    type: ""POST"",
                    enctype: 'multipart/form-data',
                    url: ""/sending/import"", // controller/functionname
                    data: data, //data this one comes fromt the data section of vuejs
                    processData: false,
                    contentType: false,
                    cache: false,");
                WriteLiteral(@"
                    timeout: 30000,
                    success: (res) => {
                        console.log(res);
                        window.location = '/sending/index';
                        window.alert(""Import Complete"");
                        location.reload();
                    },
                    error: (error) => {
                        console.log(error);
                        window.alert(""Import Fail, please re-import the correct file"");
                    },
                }; //end of option object
                //each of this attribute of this object is the parameter
                //that will identify how this request in going to look like
                //then we throw this object into the ajax() function
                $.ajax(option);
            } //end of upload function
            ,
            send_message() {
                if(confirm(""Do you want to send the message ??"")){
                var url = '/sending/send_message';
              ");
                WriteLiteral(@"  
                $.post(url)
                    .done(res => {
                        if (res.error == 200) {
                            console.log(res);
                            alert(""Message Sent"");
                            //window.location = '/sending/index'

                        } else {
                            alert(""error"");
                        }
                    });
                }//end of if
            } //end of send message function
            ,
        } //end of method
        ,
        computed: {

        }
    };
    app = new Vue(component);
</script>

");
            }
            );
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
