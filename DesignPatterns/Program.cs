using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns.Behavioral;
using DesignPatterns.Creational;
namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            //Tester.Behavioral.Visitor();
            //Tester.Behavioral.Mediator();
            //Tester.Behavioral.Observer();
            //Tester.Behavioral.Command();
            //Tester.Behavioral.State();
            //Tester.Behavioral.Strategy();
            //Tester.Creational.AbstractFactory();
            //Console.Read();
        }

        
    }

    static class Tester
    {
        public static class Behavioral
        { 
            public static void Observer()
            {
                ConcreteSubject cs = new ConcreteSubject();

                ConcreteObserver co1 = new ConcreteObserver("Observer 1");
                ConcreteObserver co2 = new ConcreteObserver("Observer 2");
                ConcreteObserver co3 = new ConcreteObserver("Observer 3");

                cs.Add(co1);
                cs.Add(co2);
                cs.Add(co3);

                cs.Notify();

                Console.Read();
            }

            public static void Visitor()
            {
                IElement e = new ConcreteElement();
                IVisitor io = new InOrderVisitor();
                IVisitor ro = new ReverseOrderVisitor();

                e.Accept(io);
                e.Accept(ro);

            }

            public static void Mediator()
            {
                IMediator m = new ConcreteMediator();

                AbstractColleage a = new ColleageA(m, "A");
                AbstractColleage b = new ColleageB(m, "B");

                a.Send(b, "Hello!");
                b.Send(a, "How are you?");
            }

            public static void Memento()
            {
                Originator o = new Originator();
                Caretaker c = new Caretaker();

                o.SetMemento(new Memento { State = "NEW" });
                c.Memento.Push(o.Create());
                o.SetMemento(new Memento { State = "OTHER" });
                o.SetMemento(c.Memento.Pop());

                //Console.WriteLine("Originator has state: " + o.)

            }

            public static void Command()
            {
                Invoker i = new Invoker();
                Receiver r = new Receiver();

                i.Do(new CommandActionA(r));
                i.Do(new CommandActionA(r));
                i.Do(new CommandActionA(r));
                i.Do(new CommandActionB(r));

                for (int k = 0; k < 10; ++k)
                    i.Undo();
            }

            public static void State()
            {
                Context c = new Context(new StateA());
                c.Request();
                c.Request();
                c.Request();
                c.Request();
            }

            public static void Strategy()
            {
                //int[] a = { 4, 2, 6, 1, 43, 22, 6, 23, 10, 60, 70, 9 };
                int[] a = { 5, 4 };
                ASort sort;
                /*
                sort = new BubbleSort { Order = ASort.Type.DESC };
                new Sort(sort).Run((int[])a.Clone(), true);

                sort = new InsertionSort { Order = ASort.Type.DESC };
                new Sort(sort).Run((int[]) a.Clone(), true);
                */
                sort = new MergeSort { Order = ASort.Type.DESC };
                new Sort(sort).Run((int[])a.Clone(), true);

                //Console.WriteLine(sort.Elapsed);

            }
        }   

        public static class Creational
        {
            public static void AbstractFactory()
            {
                new Client(new ConcreteFactory1()).Print();
                new Client(new ConcreteFactory2()).Print();
            }
        }
    }
}
