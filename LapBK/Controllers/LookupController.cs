using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using LapBK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace LapBK.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("api/Lookup/{action}", Name = "LookupApi")]
    public class LookupController : ApiController
    {
        private BangKeDS2019Entities _context = new BangKeDS2019Entities();
        [HttpGet]
        public HttpResponseMessage XaLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.DM_Xa
                         let tenXa = i.TenXa
                         orderby i.TenXa
                         select new
                         {
                             Id = i.MaXa,
                             TenXa = tenXa
                         };
            return Request.CreateResponse(DataSourceLoader.Load(lookup, loadOptions));
        }
    }
}
