using CoreWCF;
using MyContracts;

namespace MinimalAPIServer
{
    public class EchoService : IEchoService
    {
        public string Echo(string text)
        {
            System.Console.WriteLine($"Received {text} from client!");
            return text;
        }

        struct Employee
        {
            public int salary, index;
        }

        public void CalculateCosts()
        {
            int n, d, i;
            string[] input = Console.ReadLine().Split(' ');
            n = int.Parse(input[0]);
            d = int.Parse(input[1]);

            Employee e;
            Stack<Employee> high = new Stack<Employee>();
            Stack<Employee> low = new Stack<Employee>();
            List<List<int>> result = new List<List<int>>();
            for (i = 0; i <= n; ++i)
            {
                result.Add(new List<int>() { 0, 0 });
            }

            for (i = 1; i <= n; ++i)
            {
                e.salary = int.Parse(Console.ReadLine());
                e.index = i;
                if (e.salary > d)
                {
                    high.Push(e);
                }
                else if (e.salary < d)
                {
                    low.Push(e);
                }
            }

            Employee h, l;
            while (low.Count > 0)
            {
                h = high.Pop();
                l = low.Pop();
                h.salary -= (d - l.salary);
                result[l.index - 1][0] = h.index;
                result[l.index - 1][1] = d - l.salary;
                if (h.salary > d)
                {
                    high.Push(h);
                }
                else if (h.salary < d)
                {
                    low.Push(h);
                }
            }

            for (i = 1; i <= n; ++i)
            {
                Console.WriteLine($"{result[i - 1][0]} {result[i - 1][1]}");
            }
        }

        public string ComplexEcho(EchoMessage text)
        {
            System.Console.WriteLine($"Received {text.Text} from client!");
            return text.Text;
        }

        public string FailEcho(string text)
            => throw new FaultException<EchoFault>(new EchoFault() { Text = "WCF Fault OK" }, new FaultReason("FailReason"));

    }
}
