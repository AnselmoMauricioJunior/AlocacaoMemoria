namespace AlocacaoMemoria;

public class MemoryAllocationAlgorithms
{
    public List<string> FirstFit(int[] b, int[] p)
    {
        List<string> resultAllocation = new List<string>();

        var blocks = new List<int>(b);
        var processes = new List<int>(p);

        int[] allocation = new int[processes.Count];

        for (int i = 0; i < processes.Count; i++)
        {
            for (int j = 0; j < blocks.Count; j++)
            {
                if (blocks[j] >= processes[i])
                {
                    allocation[i] = j;
                    blocks[j] -= processes[i];
                    break;
                }
            }
        }

        for (int i = 0; i < processes.Count; i++)
            resultAllocation.Add($"[{(i + 1)}] - {processes[i]} - [ {allocation[i]} , {b[allocation[i]]},{blocks[allocation[i]]} ]");

        return resultAllocation;
    }

    public List<string> NextFit(int[] b, int[] p)
    {
        List<string> resultAllocation = new List<string>();
        var blocks = new List<int>(b);
        var processes = new List<int>(p);

        int[] allocation = new int[processes.Count];
        int prev = -1;

        for (int i = 0; i < processes.Count; i++)
        {
            for (int j = prev + 1; j < blocks.Count; j++)
            {
                if (blocks[j] >= processes[i])
                {
                    allocation[i] = j;
                    blocks[j] -= processes[i];
                    prev = j;
                    break;
                }

                if (j == blocks.Count - 1)
                {
                    j = -1;
                }
            }

        }
        for (int i = 0; i < processes.Count; i++)
            resultAllocation.Add($"[{(i + 1)}] - {processes[i]} - [ {allocation[i]} , {b[allocation[i]]}, {blocks[allocation[i]]} ]");

        return resultAllocation;
    }

    public List<string> WorstFit(int[] b, int[] p)
    {
        List<string> resultAllocation = new List<string>();
        var blocks = new List<int>(b);
        var processes = new List<int>(p);

        int[] allocation = new int[processes.Count];

        for (int i = 0; i < processes.Count; i++)
        {
            int worstIdx = -1;
            for (int j = 0; j < blocks.Count; j++)
            {
                if (blocks[j] >= processes[i])
                {
                    if (worstIdx == -1)
                        worstIdx = j;
                    else if (blocks[worstIdx] < blocks[j])
                        worstIdx = j;
                }
            }

            if (worstIdx != -1)
            {
                allocation[i] = worstIdx;
                blocks[worstIdx] -= processes[i];
            }
        }

        for (int i = 0; i < processes.Count; i++)
            resultAllocation.Add($"[{(i + 1)}] - {processes[i]} - [{allocation[i]}, {b[allocation[i]]},{blocks[allocation[i]]}]");

        return resultAllocation;
    }

    public List<string> BestFit(int[] b, int[] p)
    {
        List<string> resultAllocation = new List<string>();
        var blocks = new List<int>(b);
        var processes = new List<int>(p);

        int[] allocation = new int[processes.Count];

        for (int i = 0; i < processes.Count; i++)
        {
            int bestIdx = -1;
            for (int j = 0; j < blocks.Count; j++)
            {
                if (blocks[j] >= processes[i])
                {
                    if (bestIdx == -1)
                        bestIdx = j;
                    else if (blocks[bestIdx] > blocks[j])
                        bestIdx = j;
                }
            }

            if (bestIdx != -1)
            {
                allocation[i] = bestIdx;
                blocks[bestIdx] -= processes[i];
            }
        }

        for (int i = 0; i < processes.Count; i++)
            resultAllocation.Add($"[{(i + 1)}] - {processes[i]} - [{allocation[i]}, {b[allocation[i]]}, {blocks[allocation[i]]}]");

        return resultAllocation;
    }
}
