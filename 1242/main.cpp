#include <iostream>
#include <vector>
#include <set>
#include <map>
#include <sstream>
#include <algorithm>

using namespace std;

void find_werewolf_suspects(int n, const vector<pair<int, int>> &relationships, const set<int> &victims)
{
    map<int, set<int>> ancestors;
    map<int, set<int>> children;

    // Build the family tree
    for (const auto &relationship : relationships)
    {
        int child = relationship.first;
        int parent = relationship.second;
        children[parent].insert(child);
        ancestors[child].insert(parent);
        ancestors[child].insert(ancestors[parent].begin(), ancestors[parent].end());
    }

    // Find all ancestors of victims
    set<int> victim_ancestors;
    for (int victim : victims)
    {
        victim_ancestors.insert(ancestors[victim].begin(), ancestors[victim].end());
    }

    // Determine suspects (those who are not ancestors of the victims)
    set<int> suspects;
    for (int i = 1; i <= n; ++i)
    {
        if (victim_ancestors.find(i) == victim_ancestors.end() && victims.find(i) == victims.end())
        {
            suspects.insert(i);
        }
    }

    // Print suspects
    if (suspects.empty())
    {
        cout << "0" << endl;
    }
    else
    {
        for (int suspect : suspects)
        {
            cout << suspect << " ";
        }
        cout << endl;
    }
}

int main()
{
    int n;
    cin >> n;
    cin.ignore();

    vector<pair<int, int>> relationships;
    string line;
    while (getline(cin, line) && line != "BLOOD")
    {
        stringstream ss(line);
        int child, parent;
        ss >> child >> parent;
        relationships.push_back({child, parent});
    }

    set<int> victims;
    while (getline(cin, line))
    {
        if (line.empty())
            break;
        victims.insert(stoi(line));
    }

    find_werewolf_suspects(n, relationships, victims);
    return 0;
}
