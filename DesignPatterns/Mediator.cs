using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral
{
    public interface IMediator
    {
        void SendMessage(AbstractColleage from, AbstractColleage to,  String message);
    }

    public class ConcreteMediator : IMediator
    {
       // private ColleageA colA;
      //  private ColleageB colB;

        public void SendMessage(AbstractColleage from, AbstractColleage to, String message)
        {
            to.Receive(from, message);
        }
    }

    public abstract class AbstractColleage
    {
        protected IMediator mediator;
        public String Name
        {
            private set;
            get;
        }

        public AbstractColleage(IMediator mediator, String name)
        {
            this.mediator = mediator;
            this.Name = name;
        }

        public void Send(AbstractColleage to, String m)
        {
            this.mediator.SendMessage(this, to, m);
        }

        public void Receive(AbstractColleage from, String message)
        {
            Console.WriteLine(String.Format("{0} RECEIVED message from {1}: {2}",
                Name, from.Name, message));
        }

    }

    public class ColleageA : AbstractColleage
    {
        public ColleageA(IMediator mediator, String name) : base(mediator, name)
        {
        }
    }

    public class ColleageB : AbstractColleage
    {
        public ColleageB(IMediator mediator, String name) : base(mediator, name)
        {
        }
    }
}
