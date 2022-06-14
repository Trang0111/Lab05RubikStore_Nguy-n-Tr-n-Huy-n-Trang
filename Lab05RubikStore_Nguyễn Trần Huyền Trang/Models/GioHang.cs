using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab05RubikStore_Nguyễn_Trần_Huyền_Trang.Models
{
    public class GioHang
    {
        dbRubikStoreDataContext data = new dbRubikStoreDataContext();
        public int id { get; set; }
        [Display(Name = "Tên")]
        public string ten { get; set; }
        [Display(Name = "Ảnh bìa")]
        public string hinh { get; set; }
        [Display(Name = "Giá bán")]
        public Double gia { get; set; }
        [Display(Name = "Số lượng")]
        public int iSoLuong { get; set; }
        [Display(Name = "Thành tiền")]
        public Double iThanhtien
        {
            get { return iSoLuong * gia; }    
        }
        public GioHang(int id)
        {
            this.id = id;
            Rubik rubik = data.Rubiks.Single(n => n.id == id);
            ten = rubik.ten;
            hinh = rubik.hinh;
            gia = double.Parse(rubik.gia.ToString());
            iSoLuong = 1;
        }
    }
}