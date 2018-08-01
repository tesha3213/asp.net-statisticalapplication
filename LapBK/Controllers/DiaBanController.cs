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
    [Route("api/DiaBan/{action}", Name = "DiaBanApi")]
    public class DiaBanController : ApiController
    {
        private BangKeDS2019Entities _context = new BangKeDS2019Entities();

        [HttpGet]
        public HttpResponseMessage Get(DataSourceLoadOptions loadOptions) {
            var bk_diaban = _context.BK_DiaBan.Select(i => new {
                i.Id,
                i.MaXa,
                i.MaThon,
                i.MaDiaBan,
                i.TenDiaBan,
                i.TongSoHo,
                i.GhiChu,
                i.IsDiaBanMau
            });
            return Request.CreateResponse(DataSourceLoader.Load(bk_diaban, loadOptions));
        }

        [HttpPost]
        public HttpResponseMessage Post(FormDataCollection form) {
            var model = new BK_DiaBan();
            var values = JsonConvert.DeserializeObject<IDictionary>(form.Get("values"));
            PopulateModel(model, values);

            Validate(model);
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, GetFullErrorMessage(ModelState));

            var result = _context.BK_DiaBan.Add(model);
            _context.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.Created, result.Id);
        }

        [HttpPut]
        public HttpResponseMessage Put(FormDataCollection form) {
            var key = Convert.ToInt32(form.Get("key"));
            var model = _context.BK_DiaBan.FirstOrDefault(item => item.Id == key);
            if(model == null)
                return Request.CreateResponse(HttpStatusCode.Conflict, "BK_DiaBan not found");

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
            var model = _context.BK_DiaBan.FirstOrDefault(item => item.Id == key);

            _context.BK_DiaBan.Remove(model);
            _context.SaveChanges();
        }


        private void PopulateModel(BK_DiaBan model, IDictionary values) {
            string ID = nameof(BK_DiaBan.Id);
            string MA_XA = nameof(BK_DiaBan.MaXa);
            string MA_THON = nameof(BK_DiaBan.MaThon);
            string MA_DIA_BAN = nameof(BK_DiaBan.MaDiaBan);
            string TEN_DIA_BAN = nameof(BK_DiaBan.TenDiaBan);
            string TONG_SO_HO = nameof(BK_DiaBan.TongSoHo);
            string GHI_CHU = nameof(BK_DiaBan.GhiChu);
            string IS_DIA_BAN_MAU = nameof(BK_DiaBan.IsDiaBanMau);

            if(values.Contains(ID)) {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if(values.Contains(MA_XA)) {
                model.MaXa = Convert.ToString(values[MA_XA]);
            }

            if(values.Contains(MA_THON)) {
                model.MaThon = Convert.ToString(values[MA_THON]);
            }

            if(values.Contains(MA_DIA_BAN)) {
                model.MaDiaBan = Convert.ToString(values[MA_DIA_BAN]);
            }

            if(values.Contains(TEN_DIA_BAN)) {
                model.TenDiaBan = Convert.ToString(values[TEN_DIA_BAN]);
            }

            if(values.Contains(TONG_SO_HO)) {
                model.TongSoHo = Convert.ToInt32(values[TONG_SO_HO]);
            }

            if(values.Contains(GHI_CHU)) {
                model.GhiChu = Convert.ToString(values[GHI_CHU]);
            }

            if(values.Contains(IS_DIA_BAN_MAU)) {
                model.IsDiaBanMau = Convert.ToBoolean(values[IS_DIA_BAN_MAU]);
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