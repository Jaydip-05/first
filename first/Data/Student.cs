using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace first.Data
{
    public class Student
    {
        //[Key]   // we can remove the key if added in configuration file
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)] //  remove this if Configuration is added
        public int Id { get; set; }
        public string StudentName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Address { get; set; }
        
        public DateOnly Dob { get; set; }

        // Connection String :- 
        //Data Source=DESKTOP-AGMBRG9;Initial Catalog=Demodb;Integrated Security=True;Trust Server Certificate=True
    }
}
