using System.ComponentModel.DataAnnotations;

namespace GraduatePortalWeb.Model
{
    public class Grade
    {
        [Display(Name = "Grade ID: ")]
        public int GradeId { get; set; }
        /////////////////////////////////////////////////////////////
        [Display(Name = "SFA ID: ")]
        public int PersonId { get; set; }
        /////////////////////////////////////////////////////////////
        [Display(Name = "Class ID: ")]
        public int ClassId { get; set; }
        /////////////////////////////////////////////////////////////
        [Display(Name = "Letter Grade: ")]
        public String LetterGrade { get; set; }
        /////////////////////////////////////////////////////////////
        // this is not in the Grade table, so to populate must use inner join Class on ClassId
        [Display(Name = "Class Name: ")]
        public String ClassName { get; set; }
    }
}
