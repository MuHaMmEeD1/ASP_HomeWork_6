using ASP_HomeWork_6.WebUI.Services;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using ASP_HomeWork_6.WebUI.Models;

namespace ASP_HomeWork_6.WebUI.ViewComponents
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private readonly ICartSessionService _cartSessionService;

        public CartSummaryViewComponent(ICartSessionService sessionService)
        {
            _cartSessionService = sessionService;
        }

        public ViewViewComponentResult Invoke()
        {
            var model = new CartSummaryViewModel
            {
                Cart = _cartSessionService.GetCart()
            };
            return View(model);
        }
    }
}
