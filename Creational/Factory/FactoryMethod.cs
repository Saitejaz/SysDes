using System;
namespace FactoryMethod;


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


public abstract class CreateBurgerFactory
{
    public abstract Burger CreateBurger();

    public void OrderBurger()
    {
        Burger burger = CreateBurger();
        burger.prepare();
    }
}
public  class CreateBasicBurger : CreateBurgerFactory
{
    public override Burger CreateBurger()
    {
        return new BasicBurger();
    }
}

public  class CreateStandardBurger : CreateBurgerFactory
{
    public override Burger CreateBurger()
    {
        return new StandardBurger();
    }
}

public class CreatePremiumBurger : CreateBurgerFactory
{
    public override Burger CreateBurger()
    {
        return new PremiumBurger();
    }
}

public class clientCode
{
    public static void Main()
    {
        Console.WriteLine("Enter Your Choice Of Burger (Basic/Standard/Premium)?");
        string type = Console.ReadLine();
        CreateBurgerFactory Burger = null;
        switch (type)
        {
            case "basic":
                Burger = new CreateBasicBurger();
                break;

            case "standard":
                Burger = new CreateStandardBurger();
                break;

            case "premium":
                Burger = new CreatePremiumBurger();
                break;
            default:
                throw new ArgumentException("Invalid Choice!");

        }
        Burger.OrderBurger();
    }
}
