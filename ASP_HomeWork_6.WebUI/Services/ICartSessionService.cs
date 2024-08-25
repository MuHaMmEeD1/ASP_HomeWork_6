using ASP_HomeWork_6.Entities.Concrete;

namespace ASP_HomeWork_6.WebUI.Services
{
    public interface ICartSessionService
    {
        Cart GetCart();
        void SetCart(Cart cart);
    }
}
