using QL_LopHocPhan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Globalization;

namespace QL_LopHocPhan.Controllers
{
    public class SinhVienController : Controller
    {

        DatabaseDataContext db = new DatabaseDataContext();
        // GET: SinhVien
        public ActionResult Index()
        {
            return View();
        }

        //Lấy ra danh sách sinh viên
        public string GetList()
        {
            var dssv = db.tbl_SinhViens;
            return JsonConvert.SerializeObject(dssv);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public string PostCreate() {
            //xử lý thêm mới
            try
            {
                string hoTen = Request["HoTen"];
                string mSSV = Request["MSSV"];
                string diaChi = Request["DiaChi"];
                string khoaHoc = Request["KhoaHoc"];
                string lopQuanLy = Request["LopQuanLy"];
                string ngaySinh = Request["NgaySinh"];
                string gioiTinh = Request["GioiTinh"];

                tbl_SinhVien newSV = new tbl_SinhVien();
                newSV.MSSV = mSSV;
                newSV.HoTen = hoTen;
                newSV.KhoaHoc = khoaHoc;
                newSV.LopQuanLy = lopQuanLy;
                newSV.DiaChi = diaChi;
                newSV.NgaySinh = DateTime.ParseExact(ngaySinh, "yyyy-MM-dd",CultureInfo.InvariantCulture);
                newSV.GioiTinh = gioiTinh;
                db.tbl_SinhViens.InsertOnSubmit(newSV);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                return "Thêm mới sinh viên không thành công. Lỗi: "+ex.Message;
            }
            return "Thêm mới sinh viên thành công";
        }

    }
}