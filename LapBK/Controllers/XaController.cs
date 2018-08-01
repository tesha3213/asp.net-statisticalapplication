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
    [Route("api/Xa/{action}", Name = "XaApi")]
    public class XaController : ApiController
    {
        private BangKeDS2019Entities _context = new BangKeDS2019Entities();

        [HttpGet]
        public HttpResponseMessage Get(DataSourceLoadOptions loadOptions) {
            var dm_xa = _context.DM_Xa.Select(i => new {
                i.MaTinh,
                i.MaHuyen,
                i.MaXa,
                i.TenXa,
                i.TTNT,
                i.Xa,
                i.Phuong,
                i.ThiTran
            });
            return Request.CreateResponse(DataSourceLoader.Load(dm_xa, loadOptions));
        }

        [HttpPost]
        public HttpResponseMessage Post(FormDataCollection form) {
            var model = new DM_Xa();
            var values = JsonConvert.DeserializeObject<IDictionary>(form.Get("values"));
            PopulateModel(model, values);

            Validate(model);
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, GetFullErrorMessage(ModelState));

            var result = _context.DM_Xa.Add(model);
            _context.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.Created, result.MaXa);
        }

        [HttpPut]
        public HttpResponseMessage Put(FormDataCollection form) {
            var key = Convert.ToString(form.Get("key"));
            var model = _context.DM_Xa.FirstOrDefault(item => item.MaXa == key);
            if(model == null)
                return Request.CreateResponse(HttpStatusCode.Conflict, "DM_Xa not found");

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
            var model = _context.DM_Xa.FirstOrDefault(item => item.MaXa == key);

            _context.DM_Xa.Remove(model);
            _context.SaveChanges();
        }


        private void PopulateModel(DM_Xa model, IDictionary values) {
            string MA_TINH = nameof(DM_Xa.MaTinh);
            string MA_HUYEN = nameof(DM_Xa.MaHuyen);
            string MA_XA = nameof(DM_Xa.MaXa);
            string TEN_XA = nameof(DM_Xa.TenXa);
            string TTNT = nameof(DM_Xa.TTNT);
            string XA = nameof(DM_Xa.Xa);
            string PHUONG = nameof(DM_Xa.Phuong);
            string THI_TRAN = nameof(DM_Xa.ThiTran);

            if(values.Contains(MA_TINH)) {
                model.MaTinh = Convert.ToString(values[MA_TINH]);
            }

            if(values.Contains(MA_HUYEN)) {
                model.MaHuyen = Convert.ToString(values[MA_HUYEN]);
            }

            if(values.Contains(MA_XA)) {
                model.MaXa = Convert.ToString(values[MA_XA]);
            }

            if(values.Contains(TEN_XA)) {
                model.TenXa = Convert.ToString(values[TEN_XA]);
            }

            if(values.Contains(TTNT)) {
                model.TTNT = Convert.ToInt32(values[TTNT]);
            }

            if(values.Contains(XA)) {
                model.Xa = Convert.ToString(values[XA]);
            }

            if(values.Contains(PHUONG)) {
                model.Phuong = Convert.ToString(values[PHUONG]);
            }

            if(values.Contains(THI_TRAN)) {
                model.ThiTran = Convert.ToString(values[THI_TRAN]);
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