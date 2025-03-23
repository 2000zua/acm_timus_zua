using System;
using System.Collections.Generic;

class Program
{
    static void FindWerewolfSuspects(int n, List<Tuple<int, int>> relationships, HashSet<int> victims)
    {
        var ancestors = new Dictionary<int, HashSet<int>>();
        var children = new Dictionary<int, HashSet<int>>();

        // Build the family tree
        foreach (var relationship in relationships)
        {
            int child = relationship.Item1;
            int parent = relationship.Item2;
            if (!children.ContainsKey(parent)) children[parent] = new HashSet<int>();
            children[parent].Add(child);

            if (!ancestors.ContainsKey(child)) ancestors[child] = new HashSet<int>();
            ancestors[child].Add(parent);
            if (ancestors.ContainsKey(parent))
            {
                foreach (var ancestor in ancestors[parent])
                {
                    ancestors[child].Add(ancestor);
                }
            }
        }

        // Find all ancestors of victims
        var victimAncestors = new HashSet<int>();
        foreach (var victim in victims)
        {
            if (ancestors.ContainsKey(victim))
            {
                foreach (var ancestor in ancestors[victim])
                {
                    victimAncestors.Add(ancestor);
                }
            }
        }

        // Determine suspects (those who are not ancestors of the victims)
        var suspects = new HashSet<int>();
        for (int i = 1; i <= n; i++)
        {
            if (!victimAncestors.Contains(i) && !victims.Contains(i))
            {
                suspects.Add(i);
            }
        }

        // Print suspects
        if (suspects.Count == 0)
        {
            Console.WriteLine("0");
        }
        else
        {
            var sortedSuspects = new List<int>(suspects);
            sortedSuspects.Sort();
            Console.WriteLine(string.Join(" ", sortedSuspects));
        }
    }

    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        var relationships = new List<Tuple<int, int>>();
        string line;

        // Reading relationships
        while ((line = Console.ReadLine()) != "BLOOD")
        {
            var parts = line.Split();
            int child = int.Parse(parts[0]);
            int parent = int.Parse(parts[1]);
            relationships.Add(new Tuple<int, int>(child, parent));
        }

        // Reading victims
        var victims = new HashSet<int>();
        while ((line = Console.ReadLine()) != null && line.Trim() != "")
        {
            victims.Add(int.Parse(line.Trim()));
        }

        FindWerewolfSuspects(n, relationships, victims);
    }
}
