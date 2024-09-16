using System.ComponentModel.DataAnnotations;

namespace MyWebAPI.Models
{
    public class Vaccination
    {
        [Display(Name ="編號")]
        public string id { get; set; }

        [Display(Name = "發佈統計日期")]
        public string a01 { get; set; }

        [Display(Name = "廠牌")]
        public string a02 { get; set; }

        [Display(Name = "月份")]
        public string a03 { get; set; }

        [Display(Name = "第1劑")]
        public string a04 { get; set; }

        [Display(Name = "第2劑")]
        public string a05 { get; set; }

        [Display(Name = "基礎加強劑")]
        public string a06 { get; set; }

        [Display(Name = "第1次追加劑")]
        public string a07 { get; set; }

        [Display(Name = "第2次追加劑")]
        public string a08 { get; set; }

        [Display(Name = "第3次追加劑")]
        public string a09 { get; set; }

        [Display(Name = "第4次追加劑")]
        public string a10 { get; set; }

        [Display(Name = "第5次追加劑")]
        public string a11 { get; set; }
    }

}


//{ "id":"ID","a01":"發佈統計日期","a02":"廠牌","a03":"月份","a04":"第1劑",
//"a05":"第2劑","a06":"基礎加強劑","a07":"第1次追加劑","a08":"第2次追加劑",
//"a09":"第3次追加劑","a10":"第4次追加劑","a11":"第5次追加劑"}
