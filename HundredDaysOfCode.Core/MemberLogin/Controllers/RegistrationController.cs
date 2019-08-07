using HundredDaysOfCode.Core.MemberLogin.Models;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace HundredDaysOfCode.Core.MemberLogin.Controllers
{
    public class RegistrationController : SurfaceController
    {
        public ActionResult Index()
        {
            return PartialView("Registration", new RegistrationModel());
        }

        [HttpPost] 
        public ActionResult Submit(RegistrationModel model)
        {
            if (!ModelState.IsValid)
                return CurrentUmbracoPage();

            var ms = Services.MemberService;
            if (ms.GetByEmail(model.Email) != null)
            {
                ModelState.AddModelError("exists", "This email is taken.");
                return CurrentUmbracoPage();
            }

            var member = ms.CreateMemberWithIdentity(model.Email, model.Email, model.Email, "Member");
            ms.Save(member);
            ms.SavePassword(member, model.Password);
            Members.Login(model.Email, model.Password);

            return Redirect("/profile");
        }
    }
}
