//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcLibraryManagement.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TblMember
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblMember()
        {
            this.TblMove = new HashSet<TblMove>();
            this.TblFine = new HashSet<TblFine>();
        }
    
        public int ID { get; set; }
        [Required(ErrorMessage = "Name cannot be empty")]
        [StringLength(20,ErrorMessage = "Max 20 character")]
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Username { get; set; }
        [Required(ErrorMessage = "Password cannot be empty")]
        [StringLength(10, ErrorMessage = "Max 20 character")]
        public string Password { get; set; }
        public string PhotoURL { get; set; }
        public string Phone { get; set; }
        public string School { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblMove> TblMove { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblFine> TblFine { get; set; }
    }
}
