//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASPMVC5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    /// <summary>
    /// 轉換強型別
    /// </summary>
    public partial class Product
    {
        public Product()
        {
            this.OrderLine = new HashSet<OrderLine>();
        }
    
        public int ProductId { get; set; }
        //驗證前後端
        //[Required(ErrorMessage="請輸入")]
        //多國語系 --如要使用要加入WEB.config 
        [Required(ErrorMessageResourceType=typeof(Resources.ProductResource),ErrorMessageResourceName="ProductName")]
        [StringLength(5,ErrorMessage="長度不可大於5")]
        public string ProductName { get; set; }
        [Required]
        public Nullable<decimal> Price { get; set; }
        [Required]
        public Nullable<bool> Active { get; set; }
        [Required]
        public Nullable<decimal> Stock { get; set; }
        [Required]    
        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}
