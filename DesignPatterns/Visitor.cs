using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral
{
    interface IVisitor
    {
        void Visit(ConcreteElement elem);
        //void VisitConcreteElemB(ConcreteElemB elem);
    }

    class ReverseOrderVisitor : IVisitor
    {
        public void Visit(ConcreteElement elem)
        {
            int[] items = elem.Items;
            Array.Reverse(items);
            foreach (var i in items)
                Console.Write(i + " ");
            Console.WriteLine();
        }
    }


    class InOrderVisitor : IVisitor
    {
        public void Visit(ConcreteElement elem)
        {
            int[] items = elem.Items;
            foreach (var i in items)
                Console.Write(i + " ");
            Console.WriteLine();
        }
    }

    interface IElement
    {
        void Accept(IVisitor visitor);
    }

    class ConcreteElement : IElement
    {
        private int[] elem = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public int[] Items
        {
            get
            {
                return elem;
            }
        }
    }
}
