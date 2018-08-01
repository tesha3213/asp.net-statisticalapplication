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
using System.Web.Http.Cors;
using System.Web.Http.ModelBinding;

namespace LapBK.Models.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("api/Huyen/{action}", Name = "HuyenApi")]
    public class HuyenController : ApiController
    {
        private BangKeDS2019Entities _context = new BangKeDS2019Entities();

        [HttpGet]
        public HttpResponseMessage Get(DataSourceLoadOptions loadOptions) {
            var dm_huyen = _context.DM_Huyen.Select(i => new {
                i.MaTinh,
                i.MaHuyen,
                i.TenHuyen
            });
            return Request.CreateResponse(DataSourceLoader.Load(dm_huyen, loadOptions));
        }

        [HttpPost]
        public HttpResponseMessage Post(FormDataCollection form) {
            var model = new DM_Huyen();
            var values = JsonConvert.DeserializeObject<IDictionary>(form.Get("values"));
            PopulateModel(model, values);

            Validate(model);
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, GetFullErrorMessage(ModelState));

            var result = _context.DM_Huyen.Add(model);
            _context.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.Created, result.MaHuyen);
        }

        [HttpPut]
        public HttpResponseMessage Put(FormDataCollection form) {
            var key = Convert.ToString(form.Get("key"));
            var model = _context.DM_Huyen.FirstOrDefault(item => item.MaHuyen == key);
            if(model == null)
                return Request.CreateResponse(HttpStatusCode.Conflict, "DM_Huyen not found");

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
            var key = Convert.ToString(form.Get("key"));
            var model = _context.DM_Huyen.FirstOrDefault(item => item.MaHuyen == key);

            _context.DM_Huyen.Remove(model);
            _context.SaveChanges();
        }


        private void PopulateModel(DM_Huyen model, IDictionary values) {
            string MA_TINH = nameof(DM_Huyen.MaTinh);
            string MA_HUYEN = nameof(DM_Huyen.MaHuyen);
            string TEN_HUYEN = nameof(DM_Huyen.TenHuyen);

            if(values.Contains(MA_TINH)) {
                model.MaTinh = Convert.ToString(values[MA_TINH]);
            }

            if(values.Contains(MA_HUYEN)) {
                model.MaHuyen = Convert.ToString(values[MA_HUYEN]);
            }

            if(values.Contains(TEN_HUYEN)) {
                model.TenHuyen = Convert.ToString(values[TEN_HUYEN]);
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