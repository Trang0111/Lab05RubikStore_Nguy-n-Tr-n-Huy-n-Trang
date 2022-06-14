using Lab05RubikStore_Nguyễn_Trần_Huyền_Trang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab05RubikStore_Nguyễn_Trần_Huyền_Trang.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang

        dbRubikStoreDataContext data = new dbRubikStoreDataContext();
        public ActionResult Index()
        {
            return View();
        }

        public List<GioHang> Laygiohang()
        {
            List<GioHang> lstGiohang = Session["Giohang"] as List<GioHang>;
            if(lstGiohang == null)
            {
                lstGiohang = new List<GioHang>();
                Session["Giohang"] = lstGiohang;
            }
            return lstGiohang;
        }

        public ActionResult ThemGioHang(int id, string strURL)
        {
            List<GioHang> lstGiohang = Laygiohang();
            GioHang sanpham = lstGiohang.Find(n => n.id == id);
            if(sanpham == null)
            {
                sanpham = new GioHang(id);
                lstGiohang.Add(sanpham);
                return Redirect(strURL);
            } 
            else
            {
                sanpham.iSoLuong++;
                return Redirect(strURL);
            }    
        }

        private int TongSoLuong()
        {
            int tsl = 0;
            List<GioHang> lstGiohang = Session["Giohang"] as List<GioHang>;
            if(lstGiohang != null)
            {
                tsl = lstGiohang.Sum(n => n.iSoLuong);
            }
            return tsl;
        }

        private int TongSoLuongSanPham()
        {
            int tsl = 0;
            List<GioHang> lstGiohang = Session["Giohang"] as List<GioHang>;
            if (lstGiohang != null)
            {
                tsl = lstGiohang.Count;
            }
            return tsl;
        }

        private double TongTien()
        {
            double tt = 0;
            List<GioHang> lstGiohang = Session["Giohang"] as List<GioHang>;
            if (lstGiohang != null)
            {
                tt = lstGiohang.Sum(n => n.iThanhtien);
            }
            return tt;
        }

        public ActionResult GioHang()
        {
            List<GioHang> lstGiohang = Laygiohang();
            ViewBag.TongSoluong = TongSoLuong();
            ViewBag.Tongtien = TongTien();
            ViewBag.Tongsoluongsanpham = TongSoLuongSanPham();
            return View(lstGiohang);
        }
        public ActionResult GioHangPartial()
        {
            ViewBag.TongSoluong = TongSoLuong();
            ViewBag.Tongtien = TongTien();
            ViewBag.Tongsoluongsanpham = TongSoLuongSanPham();
            return PartialView();
        }
        public ActionResult XoaGiohang(int id)
        {
            List<GioHang> lstGiohang = Laygiohang();
            GioHang sanpham = lstGiohang.SingleOrDefault(n => n.id == id);
            if(sanpham != null)
            {
                lstGiohang.RemoveAll(n => n.id == id);
                return RedirectToAction("GioHang");
            }
            return RedirectToAction("GioHang");
        }
        public ActionResult CapnhatGiohang(int id, FormCollection collection)
        {
            List<GioHang> lstGiohang = Laygiohang();
            GioHang sanpham = lstGiohang.SingleOrDefault(n => n.id == id);
            if (sanpham != null)
            {
                sanpham.iSoLuong = int.Parse(collection["txtSoLg"].ToString());
            }
            return RedirectToAction("GioHang");
        }
        public ActionResult XoaTatCaGioHang()
        {
            List<GioHang> lstGiohang = Laygiohang();
            lstGiohang.Clear();
            return RedirectToAction("GioHang");
        }
        
        public ActionResult Detail(int id)
        {
            var D_rubik = data.Rubiks.Where(m => m.maloai == id).First();
            return View(D_rubik);
        }
    }
}