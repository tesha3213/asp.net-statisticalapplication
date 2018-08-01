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
    [Route("api/Tinh/{action}", Name = "DM_TinhApi")]
    public class DM_TinhController : ApiController
    {
        private BangKeDS2019Entities _context = new BangKeDS2019Entities();

        [HttpGet]
        public HttpResponseMessage Get(DataSourceLoadOptions loadOptions) {
            var dm_tinh = _context.DM_Tinh.Select(i => new {
                i.MaTinh,
                i.TenTinh,
                i.MaVung
            });
            return Request.CreateResponse(DataSourceLoader.Load(dm_tinh, loadOptions));
        }

        [HttpPost]
        public HttpResponseMessage Post(FormDataCollection form) {
            var model = new DM_Tinh();
            var values = JsonConvert.DeserializeObject<IDictionary>(form.Get("values"));
            PopulateModel(model, values);

            Validate(model);
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, GetFullErrorMessage(ModelState));

            var result = _context.DM_Tinh.Add(model);
            _context.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.Created, result.MaTinh);
        }

        [HttpPut]
        public HttpResponseMessage Put(FormDataCollection form) {
            var key = Convert.ToString(form.Get("key"));
            var model = _context.DM_Tinh.FirstOrDefault(item => item.MaTinh == key);
            if(model == null)
                return Request.CreateResponse(HttpStatusCode.Conflict, "DM_Tinh not found");

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
            var model = _context.DM_Tinh.FirstOrDefault(item => item.MaTinh == key);

            _context.DM_Tinh.Remove(model);
            _context.SaveChanges();
        }


        private void PopulateModel(DM_Tinh model, IDictionary values) {
            string MA_TINH = nameof(DM_Tinh.MaTinh);
            string TEN_TINH = nameof(DM_Tinh.TenTinh);
            string MA_VUNG = nameof(DM_Tinh.MaVung);

            if(values.Contains(MA_TINH)) {
                model.MaTinh = Convert.ToString(values[MA_TINH]);
            }

            if(values.Contains(TEN_TINH)) {
                model.TenTinh = Convert.ToString(values[TEN_TINH]);
            }

            if(values.Contains(MA_VUNG)) {
                model.MaVung = Convert.ToString(values[MA_VUNG]);
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