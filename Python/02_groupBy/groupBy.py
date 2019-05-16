
def makeData():
    data = [
        ["ソレイユ","星宮 いちご"],
        ["ソレイユ","霧矢 あおい"],
        ["ソレイユ","紫吹 蘭"],
        ["トライスター","神崎 美月"],
        ["トライスター","藤堂 ユリカ"],
        ["トライスター","一ノ瀬 かえで"]
    ]

    return data

def distinctName(people):
    tmp = []
    tmp.append(people[0][0])
    for i in range(1,len(people)):
        cnt = 0
        for x in tmp:
            if people[i][0] == x:
                cnt += 1
        if cnt == 0:
                tmp.append(people[i][0])
    return tmp

def groupByName(people):
    keys = distinctName(people)
    groups = []
    for key in keys:
        tmp = []
        for person in people:
            if key == person[0]:
                tmp.append(person)
        groups.append(tmp)
    return groups

if __name__ == "__main__":
    people = makeData()
    groups = groupByName(people)
    print(groups)

