using System;
namespace AbstractFactory;

// Burger Product
public interface IBurger
{
    public void Prepare();
}

public class BasicBurger : IBurger
{
    public void Prepare()
    {
        Console.WriteLine("Your Basic Burger is Ready!!");
    }
}

public class PremiumBurger : IBurger
{
    public void Prepare()
    {
        Console.WriteLine("Your Premium Burger is Ready!!");
    }
}


// Fries Product

interface IFries
{
    public void Prepare();
}

public class BasicFries : IFries
{
    public void Prepare()
    {
        Console.WriteLine("Your Basic Fries are Ready!!");
    }
}

public class PremiumFries : IFries
{
    public void Prepare()
    {
        Console.WriteLine("Your Premium Fries are Ready!!");
    }
}

// Product Drink
interface IDrink
{
    public void Prepare();
}

public class BasicDrink : IDrink
{
    public void Prepare()
    {
        Console.WriteLine("Your Basic Drink is Ready!!");
    }
}

public class PremiumDrink : IDrink
{
    public void Prepare()
    {
        Console.WriteLine("Your Premium Drink is Ready!!");
    }
}

// Factory

interface IMealFactory
{
    public IBurger CreateBurger();
    public IFries CreateFries();
    public IDrink CreateDrink();
}

public class BasicMealFactory : IMealFactory
{
    public IBurger CreateBurger()
    {
        return new BasicBurger();
    }

    public IFries CreateFries()
    {
        return new BasicFries();
    }

    public IDrink CreateDrink()
    {
        return new BasicDrink();
    }
}

public class PremiumMealFactory : IMealFactory
{
    public IBurger CreateBurger()
    {
        return new PremiumBurger();
    }

    public IFries CreateFries()
    {
        return new PremiumFries();
    }

    public IDrink CreateDrink()
    {
        return new PremiumDrink();
    }
}


public class clientCode
{
    public static void Main()
    {
        Console.WriteLine("Enter Your Choice Of Meal (Basic/Premium)?");
        string type = Console.ReadLine().ToLower();
        IMealFactory factory = null;
        factory = type switch
        {
            "basic" => new BasicMealFactory(),
            "premium" => new PremiumMealFactory(),
            _ => throw new ArgumentException("Invalid Choice!"),
        };
        factory.CreateBurger().Prepare();
        factory.CreateFries().Prepare();
        factory.CreateDrink().Prepare();
    }
}
