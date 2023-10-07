using MvcAppPOC.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcAppPOC.Entities
{
    public class UserPrimaryInfo
    {
        public int Id { get; set; }
        //Id tied to IdentityUser table
        public string? UserId { get; set; }
        public string? JobTitle { get; set; }
        public int Age { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser? User { get; set; }
    }
}
