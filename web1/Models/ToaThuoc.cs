﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace web1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class ToaThuoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ToaThuoc()
        {
            this.ChiTietToaThuocs = new HashSet<ChiTietToaThuoc>();
        }


        public int STT { get; set; }

        [DisplayName("Mã bệnh nhân")]
        public string MaBenhNhan { get; set; }
        [DisplayName("Bệnh được chẩn đoán")]

        public string BenhDuocChanDoan { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Ngày khám")]
        public Nullable<System.DateTime> NgayKham { get; set; }
    
        public virtual BenhNhan BenhNhan { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietToaThuoc> ChiTietToaThuocs { get; set; }
    }
}