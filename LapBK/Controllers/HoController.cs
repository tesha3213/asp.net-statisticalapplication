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
    [Route("api/Ho/{action}", Name = "HoApi")]
    public class HoController : ApiController
    {
        private BangKeDS2019Entities _context = new BangKeDS2019Entities();

        [HttpGet]
        public HttpResponseMessage Get(DataSourceLoadOptions loadOptions) {
            var bk_ho = _context.BK_Ho.Select(i => new {
                i.IdHo,
                i.MaTinh,
                i.MaHuyen,
                i.MaXa,
                i.MaThon,
                i.MaDiaBan,
                i.Latitude_V,
                i.Longitude_K,
                i.SttNha,
                i.SttHo,
                i.TTNT,
                i.TenChuHo,
                i.DiaChi,
                i.SoDienThoai,
                i.TongSoNguoi,
                i.TongSoNu,
                i.IsWebForm,
                i.IsHoMau,
                i.GhiChu,
                i.FullAddress,
                i.StreetNum,
                i.StreetName,
                i.Village,
                i.WardsName,
                i.DistrictName,
                i.CityName,
                i.StateName
            });
            return Request.CreateResponse(DataSourceLoader.Load(bk_ho, loadOptions));
        }

        [HttpPost]
        public HttpResponseMessage Post(FormDataCollection form) {
            var model = new BK_Ho();
            var values = JsonConvert.DeserializeObject<IDictionary>(form.Get("values"));
            PopulateModel(model, values);

            Validate(model);
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, GetFullErrorMessage(ModelState));

            var result = _context.BK_Ho.Add(model);
            _context.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.Created, result.IdHo);
        }

        [HttpPut]
        public HttpResponseMessage Put(FormDataCollection form) {
            var key = Convert.ToString(form.Get("key"));
            var model = _context.BK_Ho.FirstOrDefault(item => item.IdHo == key);
            if(model == null)
                return Request.CreateResponse(HttpStatusCode.Conflict, "BK_Ho not found");

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
            var model = _context.BK_Ho.FirstOrDefault(item => item.IdHo == key);

            _context.BK_Ho.Remove(model);
            _context.SaveChanges();
        }


        private void PopulateModel(BK_Ho model, IDictionary values) {
            string ID_HO = nameof(BK_Ho.IdHo);
            string MA_TINH = nameof(BK_Ho.MaTinh);
            string MA_HUYEN = nameof(BK_Ho.MaHuyen);
            string MA_XA = nameof(BK_Ho.MaXa);
            string MA_THON = nameof(BK_Ho.MaThon);
            string MA_DIA_BAN = nameof(BK_Ho.MaDiaBan);
            string LATITUDE_V = nameof(BK_Ho.Latitude_V);
            string LONGITUDE_K = nameof(BK_Ho.Longitude_K);
            string STT_NHA = nameof(BK_Ho.SttNha);
            string STT_HO = nameof(BK_Ho.SttHo);
            string TTNT = nameof(BK_Ho.TTNT);
            string TEN_CHU_HO = nameof(BK_Ho.TenChuHo);
            string DIA_CHI = nameof(BK_Ho.DiaChi);
            string SO_DIEN_THOAI = nameof(BK_Ho.SoDienThoai);
            string TONG_SO_NGUOI = nameof(BK_Ho.TongSoNguoi);
            string TONG_SO_NU = nameof(BK_Ho.TongSoNu);
            string IS_WEB_FORM = nameof(BK_Ho.IsWebForm);
            string IS_HO_MAU = nameof(BK_Ho.IsHoMau);
            string GHI_CHU = nameof(BK_Ho.GhiChu);
            string FULL_ADDRESS = nameof(BK_Ho.FullAddress);
            string STREET_NUM = nameof(BK_Ho.StreetNum);
            string STREET_NAME = nameof(BK_Ho.StreetName);
            string VILLAGE = nameof(BK_Ho.Village);
            string WARDS_NAME = nameof(BK_Ho.WardsName);
            string DISTRICT_NAME = nameof(BK_Ho.DistrictName);
            string CITY_NAME = nameof(BK_Ho.CityName);
            string STATE_NAME = nameof(BK_Ho.StateName);

            if(values.Contains(ID_HO)) {
                model.IdHo = Convert.ToString(values[ID_HO]);
            }

            if(values.Contains(MA_TINH)) {
                model.MaTinh = Convert.ToString(values[MA_TINH]);
            }

            if(values.Contains(MA_HUYEN)) {
                model.MaHuyen = Convert.ToString(values[MA_HUYEN]);
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

            if(values.Contains(LATITUDE_V)) {
                model.Latitude_V = Convert.ToDouble(values[LATITUDE_V]);
            }

            if(values.Contains(LONGITUDE_K)) {
                model.Longitude_K = Convert.ToDouble(values[LONGITUDE_K]);
            }

            if(values.Contains(STT_NHA)) {
                model.SttNha = Convert.ToString(values[STT_NHA]);
            }

            if(values.Contains(STT_HO)) {
                model.SttHo = Convert.ToString(values[STT_HO]);
            }

            if(values.Contains(TTNT)) {
                model.TTNT = Convert.ToInt32(values[TTNT]);
            }

            if(values.Contains(TEN_CHU_HO)) {
                model.TenChuHo = Convert.ToString(values[TEN_CHU_HO]);
            }

            if(values.Contains(DIA_CHI)) {
                model.DiaChi = Convert.ToString(values[DIA_CHI]);
            }

            if(values.Contains(SO_DIEN_THOAI)) {
                model.SoDienThoai = Convert.ToString(values[SO_DIEN_THOAI]);
            }

            if(values.Contains(TONG_SO_NGUOI)) {
                model.TongSoNguoi = Convert.ToInt32(values[TONG_SO_NGUOI]);
            }

            if(values.Contains(TONG_SO_NU)) {
                model.TongSoNu = Convert.ToInt32(values[TONG_SO_NU]);
            }

            if(values.Contains(IS_WEB_FORM)) {
                model.IsWebForm = Convert.ToBoolean(values[IS_WEB_FORM]);
            }

            if(values.Contains(IS_HO_MAU)) {
                model.IsHoMau = Convert.ToBoolean(values[IS_HO_MAU]);
            }

            if(values.Contains(GHI_CHU)) {
                model.GhiChu = Convert.ToString(values[GHI_CHU]);
            }

            if(values.Contains(FULL_ADDRESS)) {
                model.FullAddress = Convert.ToString(values[FULL_ADDRESS]);
            }

            if(values.Contains(STREET_NUM)) {
                model.StreetNum = Convert.ToString(values[STREET_NUM]);
            }

            if(values.Contains(STREET_NAME)) {
                model.StreetName = Convert.ToString(values[STREET_NAME]);
            }

            if(values.Contains(VILLAGE)) {
                model.Village = Convert.ToString(values[VILLAGE]);
            }

            if(values.Contains(WARDS_NAME)) {
                model.WardsName = Convert.ToString(values[WARDS_NAME]);
            }

            if(values.Contains(DISTRICT_NAME)) {
                model.DistrictName = Convert.ToString(values[DISTRICT_NAME]);
            }

            if(values.Contains(CITY_NAME)) {
                model.CityName = Convert.ToString(values[CITY_NAME]);
            }

            if(values.Contains(STATE_NAME)) {
                model.StateName = Convert.ToString(values[STATE_NAME]);
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