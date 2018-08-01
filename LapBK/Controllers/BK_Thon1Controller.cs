using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace LapBK.Models.Controllers
{
    [Route("api/BK_Thon/{action}", Name = "BK_Thon1Api")]
    public class BK_Thon1Controller : ApiController
    {
        private BangKeDS2019Entities _context = new BangKeDS2019Entities();

        [HttpGet]
        public HttpResponseMessage Get(DataSourceLoadOptions loadOptions) {
            var bk_thon = _context.BK_Thon.Select(i => new {
                i.Id,
                i.MaXa,
                i.MaThon,
                i.TenThon
            });
            return Request.CreateResponse(DataSourceLoader.Load(bk_thon, loadOptions));
        }

        [HttpPost]
        public HttpResponseMessage Post(FormDataCollection form) {
            var model = new BK_Thon();
            var values = JsonConvert.DeserializeObject<IDictionary>(form.Get("values"));
            PopulateModel(model, values);

            Validate(model);
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, GetFullErrorMessage(ModelState));

            var result = _context.BK_Thon.Add(model);
            _context.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.Created, result.Id);
        }

        [HttpPut]
        public HttpResponseMessage Put(FormDataCollection form) {
            var key = Convert.ToInt32(form.Get("key"));
            var model = _context.BK_Thon.FirstOrDefault(item => item.Id == key);
            if(model == null)
                return Request.CreateResponse(HttpStatusCode.Conflict, "BK_Thon not found");

            var values = JsonConvert.DeserializeObject<IDictionary>(form.Get("values"));
            PopulateModel(model, values);

            Validate(model);
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, GetFullErrorMessage(ModelState));

            _context.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public void Delete(FormDataCollection form) {
            var key = Convert.ToInt32(form.Get("key"));
            var model = _context.BK_Thon.FirstOrDefault(item => item.Id == key);

            _context.BK_Thon.Remove(model);
            _context.SaveChanges();
        }


        private void PopulateModel(BK_Thon model, IDictionary values) {
            string ID = nameof(BK_Thon.Id);
            string MA_XA = nameof(BK_Thon.MaXa);
            string MA_THON = nameof(BK_Thon.MaThon);
            string TEN_THON = nameof(BK_Thon.TenThon);

            if(values.Contains(ID)) {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if(values.Contains(MA_XA)) {
                model.MaXa = Convert.ToString(values[MA_XA]);
            }

            if(values.Contains(MA_THON)) {
                model.MaThon = Convert.ToString(values[MA_THON]);
            }

            if(values.Contains(TEN_THON)) {
                model.TenThon = Convert.ToString(values[TEN_THON]);
            }
        }

        private string GetFullErrorMessage(ModelStateDictionary modelState) {
            var messages = new List<string>();

            foreach(var entry in modelState) {
                foreach(var error in entry.Value.Errors)
                    messages.Add(error.ErrorMessage);
            }

            return String.Join(" ", messages);
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}