//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentGradeInformation.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Notes
    {
        public int noteId { get; set; }
        public Nullable<int> fkStudent { get; set; }
        public Nullable<int> fkLesson { get; set; }
        public Nullable<short> exam1 { get; set; }
        public Nullable<short> exam2 { get; set; }
        public Nullable<short> exam3 { get; set; }
        public Nullable<decimal> result { get; set; }
        public Nullable<bool> status { get; set; }
    
        public virtual tbl_Lesson tbl_Lesson { get; set; }
        public virtual tbl_Student tbl_Student { get; set; }
    }
}
