using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers
{
    public class CheckOutController : Controller
    {

            private readonly ApplicationDbContext _context;
            const string PromoCode = "FREE";

            public CheckOutController(ApplicationDbContext context)
            {
                _context = context;
            }

            [Authorize]
            public ActionResult AddressAndPayment()
            {
                return View();
            }

            //
            // POST: /Checkout/AddressAndPayment
            [HttpPost]
            public async Task<ActionResult> AddressAndPayment(IFormCollection values)
            {

                var order = new Order();
                order.FirstName = values["FirstName"];
                order.LastName = values["LastName"];
                order.Address = values["Address"];
                order.City = values["City"];
                order.State = values["State"];
                order.PostalCode = values["PostalCode"];
                order.Country = values["Country"];
                order.Phone = values["Phone"];
                order.Email = values["Email"];


                try
                {

                    if (string.Equals(values["PromoCode"], PromoCode,
                        StringComparison.OrdinalIgnoreCase) == false)
                    {
                        return View(order);
                    }
                    else
                    {
                        order.Username = User.Identity.Name;
                        order.OrderDate = DateTime.Now;

                        //Save Order
                        _context.Orders.Add(order);
                        _context.SaveChanges();
                    //Process the order
                    var cart = ShoppingCart.GetCart(this.HttpContext, _context);
                    cart.CreateOrder(order);

                    return RedirectToAction("Complete",
                    new { id = order.OrderId });

                       

                    }
                }
                catch
                {
                    //Invalid - redisplay with errors
                    return View(order);
                }
            }
            //
            // GET: /Checkout/Complete
            public ActionResult Complete(int id)
            {
                // Validate customer owns this order
                bool isValid = _context.Orders.Any(
                    o => o.OrderId == id &&
                    o.Username == User.Identity.Name);

                if (isValid)
                {
                    return View(id);
                }
                else
                {
                    return View("Error");
                }
            }




        }
    }
