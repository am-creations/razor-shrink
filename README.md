razor-shrink
============
Shrink Html at render time of ASP.net MVC4 application. 
It removes unnecessary space and carriage returns, saving up to ±25% of bandwidth.

Installation
============
Change pageBaseType of the web.config file int the Views directory of our project
ie:
<system.web.webPages.razor>
    <host factoryType="System.Web.Mvc.MvcWebRazorHostFactory, System.Web.Mvc, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
    <!--<pages pageBaseType="System.Web.Mvc.WebViewPage">-->
    <pages pageBaseType="RazorShrink.WebViewPageShrink">
      <namespaces>
        <add namespace="System.Web.Mvc" />
        <add namespace="System.Web.Mvc.Ajax" />
        <add namespace="System.Web.Mvc.Html" />
        <add namespace="System.Web.Optimization"/>
        <add namespace="System.Web.Routing" />        
      </namespaces>
    </pages>
  </system.web.webPages.razor>
