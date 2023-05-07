using QL_LopHocPhan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

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
    }
}