﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HangFire.Web.Pages
{
    
    #line 2 "..\..\Pages\EnqueuedJobsPage.cshtml"
    using System;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Pages\EnqueuedJobsPage.cshtml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Pages\EnqueuedJobsPage.cshtml"
    using System.Linq;
    
    #line default
    #line hidden
    using System.Text;
    
    #line 5 "..\..\Pages\EnqueuedJobsPage.cshtml"
    using Common;
    
    #line default
    #line hidden
    
    #line 7 "..\..\Pages\EnqueuedJobsPage.cshtml"
    using HangFire.Storage;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Pages\EnqueuedJobsPage.cshtml"
    using Pages;
    
    #line default
    #line hidden
    
    #line 8 "..\..\Pages\EnqueuedJobsPage.cshtml"
    using Storage.Monitoring;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    internal partial class EnqueuedJobsPage : RazorPage
    {
#line hidden

        public override void Execute()
        {


WriteLiteral("\r\n");










            
            #line 10 "..\..\Pages\EnqueuedJobsPage.cshtml"
  
    Layout = new LayoutPage
        {
            Title = Queue.ToUpperInvariant(),
            Subtitle = "Enqueued jobs",
            Breadcrumbs = new Dictionary<string, string>
                {
                    { "Queues", Request.LinkTo("/queues") }
                }
        };

    int from, perPage;

    int.TryParse(Request.QueryString["from"], out from);
    int.TryParse(Request.QueryString["count"], out perPage);

    Pager pager;
    JobList<EnqueuedJobDto> enqueuedJobs;

    using (var monitor = JobStorage.Current.GetMonitoringApi())
    {
        pager = new Pager(from, perPage, monitor.EnqueuedCount(Queue))
        {
            BasePageUrl = Request.LinkTo("/queues/" + Queue)
        };

        enqueuedJobs = monitor
            .EnqueuedJobs(Queue, pager.FromRecord, pager.RecordsPerPage);
    }


            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 41 "..\..\Pages\EnqueuedJobsPage.cshtml"
 if (pager.TotalPageCount == 0)
{

            
            #line default
            #line hidden
WriteLiteral("    <div class=\"alert alert-info\">\r\n        The queue is empty.\r\n    </div>\r\n");


            
            #line 46 "..\..\Pages\EnqueuedJobsPage.cshtml"
}
else
{

            
            #line default
            #line hidden
WriteLiteral("    <div class=\"js-jobs-list\">\r\n        <div class=\"btn-toolbar btn-toolbar-top\">" +
"\r\n            <button class=\"js-jobs-list-command btn btn-sm btn-default\"\r\n     " +
"               data-url=\"");


            
            #line 52 "..\..\Pages\EnqueuedJobsPage.cshtml"
                         Write(Request.LinkTo("/enqueued/delete"));

            
            #line default
            #line hidden
WriteLiteral(@"""
                    data-loading-text=""Deleting...""
                    data-confirm=""Do you really want to DELETE ALL selected jobs?"">
                <span class=""glyphicon glyphicon-remove""></span>
                Delete selected
            </button>

            ");


            
            #line 59 "..\..\Pages\EnqueuedJobsPage.cshtml"
       Write(RenderPartial(new PerPageSelector(pager)));

            
            #line default
            #line hidden
WriteLiteral(@"
        </div>

        <table class=""table"">
            <thead>
                <tr>
                    <th class=""min-width"">
                        <input type=""checkbox"" class=""js-jobs-list-select-all"" />
                    </th>
                    <th class=""min-width"">Id</th>
                    <th class=""min-width"">State</th>
                    <th>Job</th>
                    <th class=""align-right"">Enqueued</th>
                </tr>
            </thead>
            <tbody>
");


            
            #line 75 "..\..\Pages\EnqueuedJobsPage.cshtml"
                 foreach (var job in enqueuedJobs)
                {

            
            #line default
            #line hidden
WriteLiteral("                    <tr class=\"js-jobs-list-row hover ");


            
            #line 77 "..\..\Pages\EnqueuedJobsPage.cshtml"
                                                  Write(!job.Value.InEnqueuedState ? "obsolete-data" : null);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                        <td>\r\n                            <input type=\"checkb" +
"ox\" class=\"js-jobs-list-checkbox\" name=\"jobs[]\" value=\"");


            
            #line 79 "..\..\Pages\EnqueuedJobsPage.cshtml"
                                                                                                 Write(job.Key);

            
            #line default
            #line hidden
WriteLiteral("\" />\r\n                        </td>\r\n                        <td class=\"min-width" +
"\">\r\n                            <a href=\"");


            
            #line 82 "..\..\Pages\EnqueuedJobsPage.cshtml"
                                Write(Request.LinkTo("/job/" + job.Key));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                                ");


            
            #line 83 "..\..\Pages\EnqueuedJobsPage.cshtml"
                           Write(HtmlHelper.JobId(job.Key));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </a>\r\n");


            
            #line 85 "..\..\Pages\EnqueuedJobsPage.cshtml"
                             if (!job.Value.InEnqueuedState)
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <span title=\"Job\'s state has been changed while f" +
"etching data.\" class=\"glyphicon glyphicon-question-sign\"></span>\r\n");


            
            #line 88 "..\..\Pages\EnqueuedJobsPage.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                        </td>\r\n                        <td class=\"min-width\">\r\n  " +
"                          <span class=\"label label-default\" style=\"");


            
            #line 91 "..\..\Pages\EnqueuedJobsPage.cshtml"
                                                                 Write(JobHistoryRenderer.ForegroundStateColors.ContainsKey(job.Value.State) ? String.Format("background-color: {0};", JobHistoryRenderer.ForegroundStateColors[job.Value.State]) : null);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                                ");


            
            #line 92 "..\..\Pages\EnqueuedJobsPage.cshtml"
                           Write(job.Value.State);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </span>\r\n                        </td>\r\n           " +
"             <td>\r\n                            <span title=\"");


            
            #line 96 "..\..\Pages\EnqueuedJobsPage.cshtml"
                                    Write(HtmlHelper.DisplayMethodHint(job.Value.Job));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                                ");


            
            #line 97 "..\..\Pages\EnqueuedJobsPage.cshtml"
                           Write(HtmlHelper.DisplayMethod(job.Value.Job));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </span>\r\n                        </td>\r\n           " +
"             <td class=\"align-right\">\r\n");


            
            #line 101 "..\..\Pages\EnqueuedJobsPage.cshtml"
                             if (job.Value.EnqueuedAt.HasValue)
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <span data-moment=\"");


            
            #line 103 "..\..\Pages\EnqueuedJobsPage.cshtml"
                                              Write(JobHelper.ToStringTimestamp(job.Value.EnqueuedAt.Value));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                                    ");


            
            #line 104 "..\..\Pages\EnqueuedJobsPage.cshtml"
                               Write(job.Value.EnqueuedAt);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </span>\r\n");


            
            #line 106 "..\..\Pages\EnqueuedJobsPage.cshtml"
                            }
                            else
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <em>n/a</em>\r\n");


            
            #line 110 "..\..\Pages\EnqueuedJobsPage.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                        </td>\r\n                    </tr>\r\n");


            
            #line 113 "..\..\Pages\EnqueuedJobsPage.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n");


            
            #line 117 "..\..\Pages\EnqueuedJobsPage.cshtml"
    
            
            #line default
            #line hidden
            
            #line 117 "..\..\Pages\EnqueuedJobsPage.cshtml"
Write(RenderPartial(new Paginator(pager)));

            
            #line default
            #line hidden
            
            #line 117 "..\..\Pages\EnqueuedJobsPage.cshtml"
                                        
}

            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591
