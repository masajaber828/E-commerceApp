using System;
using System.Collections.Generic;
using Ecommerce2.console.models;
using Ecommerce2.console.Discounts;
using Ecommerce2.console.Services;


namespace Ecommerce2.console
{
    class Program
    {
        static void Main(string[] args)
        {
            //ضبط الترميز لدعم العربية
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("مرحبا بكم بمتجري الالكتروني \n");

            // إنشاء Services
            var customerService = new CustomerServices();
            var productService = new ProductServices();
            var orderService = new OrderServices();

            Customer? currentCustomer = null;

            // تسجيل أو دخول
            Console.Write("هل لديك حساب؟ (yes/no): ");
            string hasAccount =( Console.ReadLine()??"").ToLower();

            if (hasAccount == "yes")
            {
                Console.Write("ادخل اسمك الكامل: ");
                string fullName = Console.ReadLine()?? "";
                Console.Write("ادخل بريدك الإلكتروني: ");
                string email = Console.ReadLine() ?? "";

                currentCustomer = customerService.GetAll()
                    .FirstOrDefault(c => c.FullName == fullName && c.Email == email);

                if (currentCustomer == null)
                {
                    Console.WriteLine("لم يتم العثور على حساب. سيتم إنشاء حساب جديد.");
                }
            }

            // تسجيل حساب جديد إذا لم يوجد
            if (currentCustomer == null)
            {
                Console.Write("ادخل اسمك الكامل: ");
                string fullName = Console.ReadLine() ?? "";
                Console.Write("ادخل بريدك الإلكتروني: ");
                string email = Console.ReadLine() ?? "";
                Console.Write("هل أنت VIP؟ (yes/no): ");
                bool isVip = (Console.ReadLine() ?? "no").ToLower() == "yes";

                currentCustomer = customerService.Register(fullName, email, isVip);
                Console.WriteLine($"تم تسجيلك كـ {(isVip ? "VIP" : "Normal")} بنجاح!\n");
            }

            // التسوق
            List<Product> cart = new List<Product>();
            while (true)
            {
                Console.WriteLine("\nالمنتجات المتاحة:");
                var products = productService.GetAll().ToList();
                for (int i = 0; i < products.Count; i++)
                {
                    var p = products[i];
                    Console.WriteLine($"{i + 1}. {p.Name} - {p.Price}$ (الكمية المتاحة: {p.Quantity})");
                }
                Console.WriteLine("0. إنهاء التسوق وعرض الفاتورة");
                Console.WriteLine("-1. حذف منتج من العربة");
                Console.Write("اختر رقم المنتج أو إجراء: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("اختيار غير صالح.");
                    continue;
                }

                if (choice == 0) break;

                if (choice == -1)
                {
                    if (cart.Count == 0)
                    {
                        Console.WriteLine("العربة فارغة.");
                        continue;
                    }
                    Console.WriteLine("العربة الحالية:");
                    for (int i = 0; i < cart.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {cart[i].Name} x {cart[i].Quantity}");
                    }
                    Console.Write("اختر رقم المنتج للحذف: ");
                    if (int.TryParse(Console.ReadLine(), out int delIndex) && delIndex > 0 && delIndex <= cart.Count)
                    {
                        var removed = cart[delIndex - 1];
                        var original = products.First(p => p.Id == removed.Id);
                        original.UpdateQuantity(removed.Quantity);
                        cart.RemoveAt(delIndex - 1);
                        Console.WriteLine($"{removed.Name} تم حذفه من العربة.");
                    }
                    else
                    {
                        Console.WriteLine("اختيار غير صالح.");
                    }
                    continue;
                }

                if (choice < 1 || choice > products.Count)
                {
                    Console.WriteLine("اختيار غير صالح.");
                    continue;
                }

                var selectedProduct = products[choice - 1];

                Console.Write($"اختر كمية {selectedProduct.Name}: ");
                if (!int.TryParse(Console.ReadLine(), out int qty) || qty <= 0 || qty > selectedProduct.Quantity)
                {
                    Console.WriteLine("كمية غير صالحة.");
                    continue;
                }

                var existingCartItem = cart.FirstOrDefault(p => p.Id == selectedProduct.Id);
                if (existingCartItem != null)
                {
                    existingCartItem.UpdateQuantity(qty);
                }
                else
                {
                    cart.Add(new Product(selectedProduct.Id, selectedProduct.Name, selectedProduct.Price, qty));
                }
                selectedProduct.UpdateQuantity(-qty);

                Console.WriteLine($"{qty} من {selectedProduct.Name} تمت إضافتها للعربة.");
            }

            // إنشاء الطلب وحساب الفاتورة
            if (cart.Count > 0)
            {
                Order order = orderService.CreateOrder(currentCustomer, cart);

                Console.WriteLine("\n-------- الفاتورة --------");
                foreach (var p in cart)
                    Console.WriteLine($"{p.Name} x {p.Quantity} - {p.Price * p.Quantity}$");

                Console.WriteLine($"Subtotal: {order.Subtotal}$");
                Console.WriteLine($"Discount: {order.Discount}$");
                Console.WriteLine($"Total: {order.Total}$");
                Console.WriteLine($"نوع الزبون: {(currentCustomer.IsVip ? "VIP" : "Normal")}");
                Console.WriteLine("--------------------------");
            }
            else
            {
                Console.WriteLine("لم يتم إضافة أي منتجات للعربة.");
            }

            Console.WriteLine("\nشكراً لتسوقك معنا!");
            Console.ReadLine();
        }


    }
}
 



    

