using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace DesignPatterns.Creational
{
    public abstract class AbstractFactory
    {
        public abstract AbstractProductA CreateProductA();
        public abstract AbstractProductB CreateProductB();
    }

    public class ConcreteFactory1 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA1();
        }

        public override AbstractProductB CreateProductB()
        {
            return new ProductB1();
        }
    }

    public class ConcreteFactory2 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA2();
        }

        public override AbstractProductB CreateProductB()
        {
            return new ProductB2();
        }
    }

    #region HelperClasses

    public abstract class AbstractProductA
    {
        public String Name { set; get; }
    }
    public abstract class AbstractProductB
    {
        public String Name { set; get; }
    }

    public class ProductA1 : AbstractProductA
    {
        public ProductA1() : base() { Name = "ProductA1"; }
    }
    public class ProductA2 : AbstractProductA
    {
        public ProductA2() : base() { Name = "ProductA2"; }
    }

    public class ProductB1 : AbstractProductB
    {
        public ProductB1() : base() { Name = "ProductB1"; }
    }
    public class ProductB2 : AbstractProductB
    {
        public ProductB2() : base() { Name = "ProductB2"; }
    }

    #endregion HelperClasses

    public class Client
    {
        private AbstractProductA productA;
        private AbstractProductB productB;


        public Client(AbstractFactory abs)
        {
            productA = abs.CreateProductA();
            productB = abs.CreateProductB();
        }

        public void Print()
        {
            Console.WriteLine("Items selected were: " + productA.Name + " and " + productB.Name);
        }
     }


}
