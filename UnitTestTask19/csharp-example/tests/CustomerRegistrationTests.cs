using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace csharp_example
{
    [TestFixture]
    public class AddProducts : TestBase
    {
        [Test]
        public void Basket()
        {
            do
            {
                app.AddNewProduct(app.GetProductsHref());
            } while(app.GetProductsQuantity() < 3);
            do
            {
                app.DelProduct();
            } while (app.GetProductsQuantity() > 0);


        }
    }
}
