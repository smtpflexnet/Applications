using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral
{
    public abstract class AbstractSubject
    {
        public void Add(IObserver o)
        {
            observers.Add(o);
        }

        public void Remove(IObserver o)
        {
            observers.Remove(o);
        }

        public void Notify()
        {
            foreach(var o in observers)
            {
                o.Update("this is a test message");
            }
        }

        private List<IObserver> observers = new List<IObserver>();
    }

    public class ConcreteSubject : AbstractSubject
    {

    }

    public interface IObserver
    {
        void Update(Object o);
    }

    public class ConcreteObserver : IObserver
    {
        private String Name;

        public ConcreteObserver(String Name)
        {
            this.Name = Name;
        }

        public void Update(Object o)
        {
            if (o is String)
            {
                Console.WriteLine(Name + " received the message: " + o.ToString());
            }
        }
    }
}
