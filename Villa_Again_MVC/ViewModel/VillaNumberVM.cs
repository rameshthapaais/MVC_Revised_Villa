using Microsoft.AspNetCore.Mvc.Rendering;
using Villa.Domain.Entities;

namespace Villa_Again_MVC.ViewModel
{
    public class VillaNumberVM
    {
        public VillaNumber?VillaNumber { get; set; }
        public IEnumerable<SelectListItem>?VillaList { get; set; }
    }
}
