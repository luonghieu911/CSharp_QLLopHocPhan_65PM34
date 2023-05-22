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
        public ActionResult Edit()
        {
            return View();
        }

        public string GetObject(string mssv)
        {
            tbl_SinhVien sinhvien = new tbl_SinhVien();
            sinhvien = db.tbl_SinhViens.Where(o => o.MSSV.Equals(mssv)).FirstOrDefault();
            return JsonConvert.SerializeObject(sinhvien);
        }

        [HttpPost]
        public string PostCreate() {
            Result_ett<string> rs = new Result_ett<string>();
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
                rs.ErrCode = EnumErrCode.Success;
                rs.Message = "Thêm mới sinh viên thành công";
            }
            catch (Exception ex)
            {
                rs.ErrCode = EnumErrCode.Fail;
                rs.ErrDetail = ex.Message;
                rs.Message = "Thêm mới sinh viên không thành công";
                return JsonConvert.SerializeObject(rs);
            }
            return JsonConvert.SerializeObject(rs);
        }

        [HttpPost]
        public string PostEdit()
        {
            Result_ett<string> rs = new Result_ett<string>();
            try
            {
                string hoTen = Request["HoTen"];
                string mSSV = Request["MSSV"];
                string diaChi = Request["DiaChi"];
                string khoaHoc = Request["KhoaHoc"];
                string lopQuanLy = Request["LopQuanLy"];
                string ngaySinh = Request["NgaySinh"];
                string gioiTinh = Request["GioiTinh"];

                tbl_SinhVien newSV = db.tbl_SinhViens.Where(o=>o.MSSV.Equals(mSSV)).FirstOrDefault();
                newSV.HoTen = hoTen;
                newSV.KhoaHoc = khoaHoc;
                newSV.LopQuanLy = lopQuanLy;
                newSV.DiaChi = diaChi;
                newSV.NgaySinh = DateTime.ParseExact(ngaySinh, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                newSV.GioiTinh = gioiTinh;
                db.SubmitChanges();
                rs.ErrCode = EnumErrCode.Success;
                rs.Message = "Cập nhật thông tin sinh viên thành công";
            }
            catch (Exception ex)
            {
                rs.ErrCode = EnumErrCode.Fail;
                rs.ErrDetail = ex.Message;
                rs.Message = "Cập nhật thông tin sinh viên không thành công";
                return JsonConvert.SerializeObject(rs);
            }
            return JsonConvert.SerializeObject(rs);
        }
        [HttpPost]
        public string Delete(string mssv)
        {
            Result_ett<string> rs = new Result_ett<string>();
            try
            {
                tbl_SinhVien delObj = db.tbl_SinhViens.Where(o => o.MSSV.Equals(mssv)).FirstOrDefault();
                db.tbl_SinhViens.DeleteOnSubmit(delObj);
                db.SubmitChanges();
                rs.ErrCode = EnumErrCode.Success;
                rs.Message = "Xóa sinh viên thành công";
            }
            catch (Exception ex)
            {
                rs.ErrCode = EnumErrCode.Fail;
                rs.ErrDetail = ex.Message;
                rs.Message = "Xóa sinh viên không thành công";
                return JsonConvert.SerializeObject(rs);
            }
            return JsonConvert.SerializeObject(rs);
        }
    }
}