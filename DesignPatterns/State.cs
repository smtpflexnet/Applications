using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public abstract class State
    {
        public abstract void Handle(Context C);
    }

    public class StateA : State
    {
        public override void Handle(Context c)
        {
            Console.WriteLine("In StateA");
            c.State = new StateB();
        }
    }

    public class StateB : State
    {
        public override void Handle(Context c)
        {
            Console.WriteLine("In StateB");
            c.State = new StateC();
        }
    }

    public class StateC : State
    {
        public override void Handle(Context c)
        {
            Console.WriteLine("In StateC");
            //c.State = null;
        }
    }

    public class Context
    {
        public Context(State s)
        {
            this.State = s;
        }

        public void Request()
        {
            State.Handle(this);
        }

        public State State
        {
            get;
            set;
        }
    }
}
