using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels
{
    public class RoleFormViewModel
    {
        [Required, StringLength(256)]
        public string Name { get; set; }
    }
}
