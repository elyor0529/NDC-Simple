
namespace NDC.UI.Controllers
{
    using Microsoft.AspNet.Identity;
    using SoapServiceReference;
    using System;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    [Authorize]
    public class HomeController : Controller
    {
        private readonly PersonServiceClient _soap;


        public HomeController()
        {
            _soap = new PersonServiceClient();
        }

        public ActionResult Index()
        {
            var model = new SearchModel
            {
                DestinationEmail = User.Identity.GetUserName()
            };

            ViewBag.Sex = new SelectList(new[] { "Male", "Female" });

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(SearchModel model)
        {
            try
            {
                var result = await _soap.SearchAsync(model);

                if (result > 0)
                {
                    ViewBag.Success = String.Format("Found {0} result(s) of your query,please check your email.", result);
                }
                else
                {
                    ViewBag.Warning = "Not found result(s)";
                }
            }
            catch (Exception exp)
            {
                ViewBag.Danger = exp.Message.Replace(Environment.NewLine, "<br/>");
            }

            ViewBag.Sex = new SelectList(new[] { "Male", "Female" }, model.Sex);

            return View(model);
        }

    }
}