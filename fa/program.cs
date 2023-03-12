using System;
using System.Collections.Generic;

namespace fans
{
    public class State
    {
        public string Name;
        public Dictionary<char, State> Transitions;
        public bool IsAcceptState;
    }


    public class FA1
    {
        public static State a = new State()
        {
            Name = "a",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = false
        };

        public static State b = new State()
        {
            Name = "b",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = false
        };

        public static State c = new State()
        {
            Name = "c",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = false
        };

        public static State d = new State()
        {
            Name = "d",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = true
        };

        public static State e = new State()
        {
            Name = "e",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = false
        };

        State InitialState = a;

        public FA1()
        {
            a.Transitions['0'] = c;
            a.Transitions['1'] = b;

            b.Transitions['0'] = d;
            b.Transitions['1'] = b;

            c.Transitions['0'] = e;
            c.Transitions['1'] = d;

            d.Transitions['0'] = e;
            d.Transitions['1'] = d;

            e.Transitions['0'] = e;
            e.Transitions['1'] = e;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                current = current.Transitions[c];
                if (current == null)
                    return null;
            }
            return current.IsAcceptState;
        }
    }

    public class FA2
    {
        public static State a = new State()
        {
            Name = "a",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = false
        };

        public static State b = new State()
        {
            Name = "b",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = false
        };

        public static State c = new State()
        {
            Name = "c",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = false
        };

        public static State d = new State()
        {
            Name = "d",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = true
        };

        State InitialState = a;

        public FA2()
        {
            a.Transitions['0'] = b;
            a.Transitions['1'] = c;

            b.Transitions['0'] = a;
            b.Transitions['1'] = d;

            c.Transitions['0'] = d;
            c.Transitions['1'] = a;

            d.Transitions['0'] = c;
            d.Transitions['1'] = b;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                current = current.Transitions[c];
                if (current == null)
                    return null;
            }
            return current.IsAcceptState;
        }
    }

    public class FA3
    {
        public static State a = new State()
        {
            Name = "a",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = false
        };

        public static State b = new State()
        {
            Name = "b",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = false
        };

        public static State c = new State()
        {
            Name = "c",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = true
        };

        State InitialState = a;

        public FA3()
        {
            a.Transitions['0'] = a;
            a.Transitions['1'] = b;

            b.Transitions['0'] = a;
            b.Transitions['1'] = c;

            c.Transitions['0'] = c;
            c.Transitions['1'] = c;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                current = current.Transitions[c];
                if (current == null)
                    return null;
            }
            return current.IsAcceptState;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            String s = "01111";
            FA1 fa1 = new FA1();
            bool? result1 = fa1.Run(s);
            Console.WriteLine(result1);
            FA2 fa2 = new FA2();
            bool? result2 = fa2.Run(s);
            Console.WriteLine(result2);
            FA3 fa3 = new FA3();
            bool? result3 = fa3.Run(s);
            Console.WriteLine(result3);
        }
    }
}