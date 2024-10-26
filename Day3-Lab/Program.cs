namespace Day3_Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var D1 = new Duration(1, 2, 4);
            var D2 = new Duration(1, 2, 4);

            Console.WriteLine(D1.Equals(D2));

            var D3 = D1 + D2;
            Console.WriteLine(D3);

            Console.WriteLine($"D1--: {D1--}");
            Console.WriteLine($"D1++: {D1++}");
        }
    }
}
