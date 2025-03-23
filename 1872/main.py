n = int(input())
S = list(map(int, input().split()))
A = [0] * n
B = [0] * n
g = [[] for _ in range(n)]
mt = [-1] * n
used = [False] * n
c = 0

# Reading A and B arrays
for i in range(n):
    A[i], B[i] = map(int, input().split())

# Constructing graph
for i in range(n):
    for j in range(n):
        if A[j] <= S[i] <= B[j]:
            g[i].append(j)

# Kuhn's algorithm
def kuhn(v):
    if used[v]:
        return False
    used[v] = True
    for to in g[v]:
        if mt[to] == -1 or kuhn(mt[to]):
            mt[to] = v
            return True
    return False

# Initial matching
used1 = [False] * n
for i in range(n):
    for j in range(len(g[i])):
        if mt[g[i][j]] == -1:
            mt[g[i][j]] = i
            used1[i] = True
            c += 1
            break

# Kuhn's algorithm for unfilled matchings
for v in range(n):
    if not used1[v]:
        used = [False] * n
        if kuhn(v):
            c += 1

if c != n:
    print("Let's search for another office.")
else:
    for i in range(n):
        for j in range(n):
            if mt[j] == -1 or mt[i] == -1:
                continue
            if i != j and A[j] <= S[mt[i]] <= B[j] and A[i] <= S[mt[j]] <= B[i]:
                print("Ask Shiftman for help.")
                exit()

    print("Perfect!")
    for i in range(n):
        if mt[i] != -1:
            print(mt[i] + 1, end=" ")
