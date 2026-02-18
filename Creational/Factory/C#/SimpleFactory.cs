using System;


// Problems with Simple Factory is It Breaks th OCP if we are going to add a new type of Burger, 
// because we need to update the BurgerFactoery in that case which breaks the OCP.
namespace SimpleFactory
{
    public abstract class Burger
    {
        public abstract void prepare();
    }

    public class BasicBurger : Burger
    {
        public override void prepare()
        {
            Console.WriteLine("Your Basic Burger is Ready!!");
        }
    }

    public class StandardBurger : Burger
    {
        public override void prepare()
        {
            Console.WriteLine("Your Standard Burger is Ready!!");
        }
    }

    public class PremiumBurger : Burger
    {
        public override void prepare()
        {
            Console.WriteLine("Your Premium Burger is Ready!!");
        }
    }


    public static class BurgerFactory
    {
        public static Burger createBurger(string burgerType)
        {
            string type = burgerType.ToLower();
            switch (type)
            {
                case "basic":
                    return new BasicBurger();

                case "standard":
                    return new StandardBurger();

                case "premium":
                    return new PremiumBurger();

                default:
                    throw new ArgumentException("Invalid Case");
            }

        }
    }

    public class clientCode
    {
        public static void Main()
        {
            Console.WriteLine("Enter Your Choice Of Burger (Basic/Standard/Premium)?");
            string type = Console.ReadLine();
            try
            {
                Burger burger = BurgerFactory.createBurger(type);
                burger.prepare();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
