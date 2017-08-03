using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral
{
    public class Receiver
    {
        public void ActionA()
        {
            Console.WriteLine("Action A");
        }

        public void ActionB()
        {
            Console.WriteLine("Action B");
        }
    }

    interface ICommand
    {
        void Execute();
    }

    class CommandActionA : ICommand
    {
        private Receiver receiver;

        public CommandActionA(Receiver r)
        {
            this.receiver = r;
        }

        public void Execute()
        {
            receiver.ActionA();
        }
    }

    class CommandActionB : ICommand
    {
        private Receiver receiver;

        public CommandActionB(Receiver r)
        {
            this.receiver = r;
        }

        public void Execute()
        {
            receiver.ActionB();
        }
    }

    class Invoker
    {
        private Stack<ICommand> _do = new Stack<ICommand>();
        private Stack<ICommand> undo = new Stack<ICommand>();

        public void Do(ICommand c)
        {
            Console.Write("Doing ");
            _do.Push(c);
            c.Execute();
        }

        public void Undo()
        {
            if(_do.Count > 0)
            {
                Console.Write("Undoing ");
                ICommand c = _do.Pop();
                undo.Push(c);
                c.Execute();
            }

        }

    }
}
