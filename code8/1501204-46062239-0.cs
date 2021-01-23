    1 - add em 'References' the dll System.Web.ApplicationServices.
    2 - Find in you web.config the tag down.
    <system.web>
    ....
     <webServices>
       <protocols>
          <remove name="Documentation"/>
       <protocols>
     </webServices>
    </sytem.web>
