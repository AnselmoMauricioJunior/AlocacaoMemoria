using AlocacaoMemoria;

int[] blocks = new int[] { 100, 500, 200, 300, 600 };
int[] processes = new int[] { 212, 417, 112, 426 };

MemoryAllocationAlgorithms algorithms = new MemoryAllocationAlgorithms();

Console.WriteLine("First Fit:");
Console.WriteLine(string.Join(Environment.NewLine, algorithms.FirstFit(blocks, processes)));

Console.WriteLine("\nNext Fit:");
Console.WriteLine(string.Join(Environment.NewLine,algorithms.NextFit(blocks, processes)));

Console.WriteLine("Worst Fit:");
Console.WriteLine(string.Join(Environment.NewLine, algorithms.WorstFit(blocks, processes)));

Console.WriteLine("\nBest Fit:");
Console.WriteLine(string.Join(Environment.NewLine, algorithms.BestFit(blocks, processes)));
