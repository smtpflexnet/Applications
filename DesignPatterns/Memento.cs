using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral
{
    class Memento
    {
        public Object State
        {
            set;
            get;
        }
    }

    class Originator
    {
        private Object state;

        public void SetMemento(Memento m)
        {
            state = m.State; // dependency
        }

        public Memento Create()
        {
            return new Memento { State = state }; //initializer list
        }
    }

    class Caretaker
    {
        public Stack<Memento> Memento
        {
            set;
            get;
        }    
    }
}
